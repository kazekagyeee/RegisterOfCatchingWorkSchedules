using RegisterOfCatchingWorkSchedules.Coltrollers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules.View
{
	public partial class RegisterRecordForm : Form
	{
		private int _currentPlanId;
		private bool _hasSomeRecords;
		private int _userMunicipalty;

		private bool _isInitialized = false;

		private const int PlaceColumnWidth = 200;
		private const int DayColumnWidth = 27;

		private Dictionary<int, int> _placesIdIndexMap;
		private Dictionary<int, int> _placesIndexIdMap;
		private BindingList<Statuses> _statuses;

		public RegisterRecordForm(int planId)
		{
			InitializeComponent();
			var user = UserController.GetCurrentUser();
			InitComboboxes();
			InitDataGrid(user.UserMunicipality);
			tbMunicipality.Text = user.Municipality.MunicipalityName;
			_userMunicipalty = user.UserMunicipality;
			var plan = PlanController.GetPlan(planId);
			if (plan != null)
				LoadPlanInfo(plan, true);
			else
				CreatePlan();

			_isInitialized = true;
		}

		private void InitComboboxes()
		{
			_statuses = StatusesController.GetStatusesBindingList();
			cbStatus.DataSource = _statuses;
			cbStatus.ValueMember = "ID";
			cbStatus.DisplayMember = "StatusName";
		}

		private void InitDataGrid(int municipalityID)
		{
			dgvPlan.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Район", DataPropertyName = "Place", Width = PlaceColumnWidth, ReadOnly = true });
			AddPlacesToDataGrid(municipalityID);
			for (int i = 1; i <= 31; i++)
			{
				var day = new DataGridViewCheckBoxColumn
				{
					HeaderText = i.ToString(),
					DataPropertyName = i.ToString(),
					Width = DayColumnWidth,
				};
				dgvPlan.Columns.Add(day);
			}
			dgvPlan.RowHeadersWidth = 20;
			dgvPlan.DataError += (s, e) => e.ThrowException = false;
		}

		private void AddPlacesToDataGrid(int municipalityID)
		{
			var placesList = MunicipaltyController.GetMunicipaltyPlaces(municipalityID);
			_placesIdIndexMap = placesList.Select((x, i) => (x.ID, i)).ToDictionary(x => x.ID, x => x.i);
			_placesIndexIdMap = placesList.Select((x, i) => (x.ID, i)).ToDictionary(x => x.i, x => x.ID);
			foreach (var place in placesList)
			{
				dgvPlan.Rows.Add(place.PlacesName);
			}
		}

		private void LoadPlanInfo(Plans plan, bool diableDateEditing)
		{
			_currentPlanId = plan.ID;
			dtpDate.Value = plan.PlanDate.Value;
			cbStatus.SelectedItem = _statuses.First(x => x.ID == plan.PlanStatusID);

			ConfigureDayColumns();
			LoadPlanTableData(plan);

			if (diableDateEditing)
			{
				dtpDate.Enabled = false;
			}
			EnableTableEditing();
		}

		private void EnableTableEditing()
		{
			dgvPlan.Enabled = true;
		}

		private void LoadPlanTableData(Plans plan)
		{
			foreach (var task in plan.Records)
			{
				_hasSomeRecords = true;
				dgvPlan.Rows[_placesIdIndexMap[task.PlaceID]].Cells[task.RecordDate.Value.Day].Value = true;
			}
		}

		private void OpenPlanHistory(object sender, EventArgs e)
		{
			new StatusHistoryForm(_currentPlanId).ShowDialog();
		}

		private void OnDateChanged(object sender, EventArgs e)
		{
			ConfigureDayColumns();

			if (_currentPlanId == -1)
			{
				CreatePlan();
			}
			else if (_currentPlanId != -1 && _isInitialized && (!_hasSomeRecords || IsUserAgreedToClearTableData()))
			{
				ClearTableData();
				PlanController.RemoveAllRecords(_currentPlanId);
				PlanController.SetPlanDate(_currentPlanId, dtpDate.Value);
			}
		}

		private void ConfigureDayColumns()
		{
			var daysInMonth = DateTime.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month);
			for (int i = 0; i < dgvPlan.ColumnCount; i++)
				dgvPlan.Columns[i].Visible = i <= daysInMonth;
		}

		private void ClearTableData()
		{
			dgvPlan.Rows.Clear();
			AddPlacesToDataGrid(_userMunicipalty);
		}

		private bool IsUserAgreedToClearTableData()
		{
			return MessageBox.Show("Данное изменение приведет к очистке табличной части!\nПродолжить?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes;
		}

		private void OnStatusChanged(object sender, EventArgs e)
		{
			if (!_isInitialized || _currentPlanId < 0)
				return;
			var status = (Statuses)cbStatus.SelectedItem;
			if (status == null)
				return;
			PlanController.SetPlanStatus(_currentPlanId, status);
		}

		private void OnDataGridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 1)
				return;
			_hasSomeRecords = true;
			var areaId = GetDataGridRowPlaceID(e.RowIndex);
			var cell = dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (areaId < 0)
			{
				cell.Value = false;
				MessageBox.Show("Сначала вам необходимо выбрать место!");
				return;
			}
			if ((bool)cell.Value)
				PlanController.AddRecord(_currentPlanId, areaId, int.Parse(dgvPlan.Columns[e.ColumnIndex].DataPropertyName));
			else
				PlanController.RemoveRecord(_currentPlanId, areaId, int.Parse(dgvPlan.Columns[e.ColumnIndex].DataPropertyName));
		}

		private int GetDataGridRowPlaceID(int rowIndex) => _placesIndexIdMap[rowIndex];

		private void CreatePlan()
		{
			var plan = PlanController.CreatePlan(dtpDate.Value);
			LoadPlanInfo(plan, false);
		}
	}
}
