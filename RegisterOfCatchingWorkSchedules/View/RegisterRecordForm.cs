using Equin.ApplicationFramework;
using RegisterOfCatchingWorkSchedules.Coltrollers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules.View
{
	public partial class RegisterRecordForm : Form
	{
		private int _currentPlanId;
		private int _selectedRowPlaceID;

		private bool _isInitialized = false;

		private const int PlaceColumnWidth = 200;
		private const int DayColumnWidth = 27;

		public RegisterRecordForm(int planId)
		{
			InitializeComponent();
			var user = UserController.GetCurrentUser();
			InitComboboxes();
			InitDataGrid(user.UserMunicipality.Value);
			tbMunicipality.Text = user.Municipality.MunicipalityName;
			_currentPlanId = planId;

			var plan = PlanController.GetPlan(planId);
			if (plan != null)
				LoadPlanInfo(plan, true);

			_isInitialized = true;
		}

		private void InitComboboxes()
		{
			cbStatus.DataSource = StatusesController.GetStatusesBindingList();
			cbStatus.ValueMember = "ID";
			cbStatus.DisplayMember = "StatusName";
		}

		private void InitDataGrid(int municipalityID)
		{
			var places = new DataGridViewComboBoxColumn
			{
				HeaderText = "Район",
				DataPropertyName = "Place",
				Width = PlaceColumnWidth,
				DataSource = new BindingListView<Places>(MunicipaltyController.GetAllPlaces()),
				ValueMember = "ID",
				DisplayMember = "PlacesName",
			};
			dgvPlan.Columns.Add(places);
			((dgvPlan.Columns[0] as DataGridViewComboBoxColumn).DataSource as BindingListView<Places>).ApplyFilter(x => x.MunicipalityID == municipalityID);
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

		private void DisableEditing()
		{
			dtpDate.Enabled = false;
		}

		private void LoadPlanInfo(Plans plan, bool diableHeaderEditing)
		{
			dtpDate.Value = plan.PlanDate.Value;
			cbStatus.SelectedItem = plan.Statuses;

			ConfigureDayColumns();
			LoadPlanTableData(plan);

			if (diableHeaderEditing)
			{
				dtpDate.Enabled = false;
			}
			EnableTableEditing();
		}

		private void EnableTableEditing()
		{
			dgvPlan.Enabled = true;
			dgvPlan.AllowUserToAddRows = true;
		}

		private void LoadPlanTableData(Plans plan)
		{
			var addedAreas = new Dictionary<int, int>();
			foreach (var task in plan.Records)
			{
				if (!addedAreas.ContainsKey(task.Places.ID))
					addedAreas[task.Places.ID] = dgvPlan.Rows.Add(task.Places.ID, false);
				dgvPlan.Rows[addedAreas[task.Places.ID]].Cells[task.RecordDate.Value.Day].Value = true;
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
			else if (_currentPlanId != -1 && IsUserAgreedToClearTableData())
			{
				ClearTableData();
				PlanController.SetPlanDate(_currentPlanId, dtpDate.Value);
			}
		}

		private void ConfigureDayColumns()
		{
			var daysInMonth = DateTime.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month);
			for (int i = 0; i < dgvPlan.ColumnCount; i++)
				dgvPlan.Columns[i].Visible = i <= daysInMonth;
		}

		private void OnMunicipalityChanged(object sender, EventArgs e)
		{
			//TODO: clear table, show message
			if (!_isInitialized)
				return;

			if (dtpDate.Value != DateTime.MinValue && _currentPlanId == -1)
			{
				CreatePlan();
			}
			else if (_currentPlanId != -1 && IsUserAgreedToClearTableData())
			{
				ClearTableData();
			}
		}

		private void ClearTableData()
		{
			dgvPlan.Rows.Clear();
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

		private void OnDataGridRowRemoving(object sender, DataGridViewRowCancelEventArgs e) => RemovePlace(GetDataGridRowPlaceID(e.Row.Index));

		private void OnRowSelected(object sender, DataGridViewCellEventArgs e) => _selectedRowPlaceID = GetDataGridRowPlaceID(e.RowIndex);

		private void OnRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			foreach (DataGridViewRow row in dgvPlan.Rows)
				RemovePlace(GetDataGridRowPlaceID(row.Index));
		}

		private void OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 0)
				return;
			PlanController.EditPlace(_currentPlanId, _selectedRowPlaceID, GetDataGridRowPlaceID(e.RowIndex));
		}

		private void RemovePlace(int placeID) => PlanController.RemovePlace(_currentPlanId, placeID);

		private void CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvPlan.IsCurrentCellDirty)
			{
				// This fires the cell value changed event
				dgvPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private int GetDataGridRowPlaceID(int rowIndex) => (int)(dgvPlan.Rows[rowIndex].Cells[0].Value ?? -1);

		private void CreatePlan()
		{
			var plan = PlanController.CreatePlan(dtpDate.Value);
			_currentPlanId = plan.ID;
			cbStatus.SelectedItem = plan.Statuses;
		}
	}
}
