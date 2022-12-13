using RegisterOfCatchingWorkSchedules.Controller;
using RegisterOfCatchingWorkSchedules.Model;
using Equin.ApplicationFramework;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules.View
{
    public partial class RegisterRecordForm : Form
	{
		private Plan? _currentPlan;
		private bool _hasUnsavedChanges = false;

		private bool _isInitialized = false;

		private const int PlaceColumnWidth = 200;
		private const int DayColumnWidth = 27;

		private Dictionary<int, LocalityArea> _areasIdMap;
		private List<int> _currentAreasId = new();

		public RegisterRecordForm(Plan? plan)
		{
			InitializeComponent();

			InitComboboxes();
			InitDataGrid();

			if (plan != null)
				LoadPlanInfo(plan, true);

			_isInitialized = true;
		}

		private void InitComboboxes()
		{
			cbLocality.DataSource = LocalityController.GetLocalitiesBindingList();
			cbLocality.ValueMember = "Id";
			cbLocality.DisplayMember = "Name";
			cbLocality.SelectedIndex = -1;

			cbStatus.DataSource = StatusesController.GetStatusesBindingList();
			cbStatus.ValueMember = "Id";
			cbStatus.DisplayMember = "Name";
		}

		private void InitDataGrid()
		{
			var areas = LocalityController.GetAllAreas();
			var areasBindingList = new BindingListView<LocalityArea>(areas);
			var places = new DataGridViewComboBoxColumn
			{
				HeaderText = "Район",
				DataPropertyName = "Area",
				Width = PlaceColumnWidth,
				DataSource = areasBindingList,
				ValueMember = "Id",
				DisplayMember = "Name",
			};
			_areasIdMap = areas.ToDictionary(x => x.Id, x => x);
			dgvPlan.Columns.Add(places);
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
			cbStatus.Enabled = false;
			dtpDate.Enabled = false;
			cbLocality.Enabled = false;
		}

		private void LoadPlanInfo(Plan plan, bool diableHeaderEditing)
		{
			_currentPlan = plan;
			dtpDate.Value = plan.Date;
			cbLocality.SelectedItem = plan.Locality;
			cbStatus.SelectedItem = plan.Status;

			ConfigureDayColumns();
			LoadPlanTableData(plan);
			if (!plan.IsEditable)
			{
				DisableEditing();
				return;
			}
			if (diableHeaderEditing)
			{
				dtpDate.Enabled = false;
				cbLocality.Enabled = false;
			}
			cbStatus.Enabled = true;
			EnableTableEditing();
		}

		private void LoadPlanTableData(Plan plan)
		{
			foreach (var task in plan.Tasks)
			{
				//var taskArea = LocalityController.GetAreaById(task.Area.Id);
				var rowIndex = dgvPlan.Rows.Add(task.Area.Id, false);
				//((DataGridViewComboBoxCell)dgvPlan.Rows[rowIndex].Cells[0]).Value = task.Area.Id;
				foreach (var day in TaskController.GetDailyTasks(task))
					dgvPlan.Rows[rowIndex].Cells[day].Value = true;
			}
		}

		private void EnableTableEditing()
		{
			dgvPlan.Enabled = true;
			dgvPlan.AllowUserToAddRows = true;
		}

		private void OpenPlanHistory(object sender, EventArgs e) => new StatusHistoryForm(_currentPlan).ShowDialog();

		private void OnDateChanged(object sender, EventArgs e)
		{
			if (!_isInitialized)
				return;
			ConfigureDayColumns();

			_hasUnsavedChanges = true;
			if (cbLocality.SelectedIndex > 0 && _currentPlan == null)
			{
				CreatePlan();
			}
			else if (_currentPlan != null && IsUserAgreedToClearTableData())
			{
				ClearTableData();
				PlanController.SetDate(_currentPlan, dtpDate.Value);
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
			if (!_isInitialized)
				return;

			_hasUnsavedChanges = true;
			var locality = (Locality)cbLocality.SelectedItem;
			if (dtpDate.Value != DateTime.MinValue && _currentPlan == null)
			{
				CreatePlan();
			}
			else if (_currentPlan != null && IsUserAgreedToClearTableData())
			{
				ClearTableData();
				PlanController.SetLocality(_currentPlan, locality);
			}
			((BindingListView<LocalityArea>)((DataGridViewComboBoxColumn)dgvPlan.Columns[0]).DataSource).ApplyFilter(x => x.Locality.Id == locality.Id);
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
			if (!_isInitialized || _currentPlan == null)
				return;
			
			_hasUnsavedChanges = true;
			var status = (PlanStatus)cbStatus.SelectedItem;
			if (status == null)
				return;
			PlanController.SetStatus(_currentPlan, status);
		}

		private void OnDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 1)
				return;

			var areaId = GetDataGridRowAreaID(e.RowIndex);
			var cell = dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (areaId < 0)
			{
				cell.Value = false;
				MessageBox.Show("Сначала вам необходимо выбрать место!");
				return;
			}
			_hasUnsavedChanges = true;
			if ((bool)cell.Value)
				PlanController.AddDailyTask(_currentPlan, areaId, int.Parse(dgvPlan.Columns[e.ColumnIndex].DataPropertyName));
			else
				PlanController.RemoveDailyTask(_currentPlan, areaId, int.Parse(dgvPlan.Columns[e.ColumnIndex].DataPropertyName));
		}

		private void OnDataGridRowRemoving(object sender, DataGridViewRowCancelEventArgs e) => RemoveArea(GetDataGridRowAreaID(e.Row.Index));

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			if (_currentPlan == null)
				return;
			if (_hasUnsavedChanges && MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Save();
			else if (_hasUnsavedChanges)
				PlanController.RevertChanges(_currentPlan);
		}

		private void OnSave(object sender, EventArgs e) => Save();

		private void OnRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			var removedCount = 0;
			foreach (DataGridViewRow row in dgvPlan.Rows)
			{
				RemoveArea(GetDataGridRowAreaID(row.Index));
				_currentAreasId.RemoveAt(row.Index - removedCount);
			}
		}

		private void OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 0)
				return;

			_hasUnsavedChanges = false;
			var newAreaId = GetDataGridRowAreaID(e.RowIndex);
			if (_currentAreasId[e.RowIndex] < 0)
				PlanController.AddAreaTask(_currentPlan, newAreaId);
			else
				PlanController.ChangeArea(_currentPlan, _currentAreasId[e.RowIndex], newAreaId);
			_currentAreasId[e.RowIndex] = newAreaId;
		}

		private void RemoveArea(int areaId)
		{
			_hasUnsavedChanges = true;
			PlanController.RemoveAreaTask(_currentPlan, areaId);
		}

		private void CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvPlan.IsCurrentCellDirty)
			{
				// This fires the cell value changed event
				dgvPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private int GetDataGridRowAreaID(int rowIndex) => (int)(dgvPlan.Rows[rowIndex].Cells[0].Value ?? -1); //TODO check if row index > 0 (-1 is for column header)

		private void Save()
		{
			//yes, im genius
			_hasUnsavedChanges = false;
		}

		private void CreatePlan()
		{
			_hasUnsavedChanges = true;
			var plan = PlanController.CreatePlan(dtpDate.Value, (Locality)cbLocality.SelectedItem);
			LoadPlanInfo(plan, false);
		}

		private void OnRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
				_currentAreasId.Add(GetDataGridRowAreaID(i));
		}
	}
}
