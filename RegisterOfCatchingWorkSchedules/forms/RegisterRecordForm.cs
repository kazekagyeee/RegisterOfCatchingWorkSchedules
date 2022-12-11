using Equin.ApplicationFramework;
using System;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	public partial class RegisterRecordForm : Form
	{
		private int _currentPlanId;
		private bool _hasUnsavedChanges = false;
		private int _selectedRowPlaceID;

		private bool _isInitialized = false;

		private const int PlaceColumnWidth = 200;
		private const int DayColumnWidth = 27;

		public RegisterRecordForm(int planId)
		{
			InitializeComponent();

			InitComboboxes();
			InitDataGrid();
			_currentPlanId = planId;

			if (planId != -1)
				LoadPlanInfo(planId);
			//if () //TODO: session
			//DisableEditing();

			_isInitialized = true;
		}

		private void InitComboboxes()
		{
			cbMunicipalty.DataSource = MunicipaltyController.GetMunicipalitiesBindingList();
			cbMunicipalty.ValueMember = "ID";
			cbMunicipalty.DisplayMember = "MunicipalityName";
			cbMunicipalty.SelectedIndex = -1;

			cbStatus.DataSource = StatusesController.GetStatusesBindingList();
			cbStatus.ValueMember = "ID";
			cbStatus.DisplayMember = "StatusName";
		}

		private void InitDataGrid()
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
			cbMunicipalty.Enabled = false;
		}

		private void LoadPlanInfo(int id)
		{
			var plan = PlanController.GetPlan(id);
			dtpDate.Value = plan.PlanDate.Value;
			cbMunicipalty.SelectedValue = plan.PlanMunicipalityID;
			cbStatus.SelectedValue = plan.Statuses;

			dtpDate.Enabled = false;
			cbMunicipalty.Enabled = false;
			cbStatus.Enabled = true;
		}

		private void OpenPlanHistory(object sender, EventArgs e)
		{
			new StatusHistoryForm(_currentPlanId).ShowDialog();
		}

		private void OnDateChanged(object sender, EventArgs e)
		{
			//TODO: clear table, show message
			if (!_isInitialized)
				return;
			if (cbMunicipalty.SelectedIndex > 0 && _currentPlanId == -1)
			{
				CreatePlan();
			}
			else if (_currentPlanId != -1 && IsUserAgreedToClearTableData())
			{
				ClearTableData();
				PlanController.SetPlanDate(_currentPlanId, dtpDate.Value);
			}
			_hasUnsavedChanges = true;
		}

		private void OnMunicipalityChanged(object sender, EventArgs e)
		{
			//TODO: clear table, show message
			if (!_isInitialized)
				return;

			var municipalty = (Municipality)cbMunicipalty.SelectedItem;
			if (dtpDate.Value != DateTime.MinValue && _currentPlanId == -1)
			{
				CreatePlan();
			}
			else if (_currentPlanId != -1 && IsUserAgreedToClearTableData())
			{
				ClearTableData();
				PlanController.SetPlanMunicipalty(_currentPlanId, municipalty);
			}
			((dgvPlan.Columns[0] as DataGridViewComboBoxColumn).DataSource as BindingListView<Places>).ApplyFilter(x => x.MunicipalityID == municipalty.ID);
			_hasUnsavedChanges = true;
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
			_hasUnsavedChanges = true;
		}

		private void OnDataGridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 1)
				return;
			if ((bool)dgvPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
				PlanController.AddRecord(_currentPlanId, _selectedRowPlaceID, int.Parse(dgvPlan.Columns[e.ColumnIndex].DataPropertyName));
			else
				PlanController.DeleteRecord(_currentPlanId, _selectedRowPlaceID, int.Parse(dgvPlan.Columns[e.ColumnIndex].DataPropertyName));
			_hasUnsavedChanges = true;
		}

		private void OnDataGridRowRemoving(object sender, DataGridViewRowCancelEventArgs e) => RemovePlace(GetDataGridRowPlaceID(e.Row.Index));

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			if (_currentPlanId == -1)
				return;
			if (_hasUnsavedChanges && MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Save();
			else
				PlanController.RevertChanges(_currentPlanId);
		}

		private void OnSave(object sender, EventArgs e) => Save();

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
			_hasUnsavedChanges = false;
		}

		private void RemovePlace(int placeID)
		{
			PlanController.RemovePlace(_currentPlanId, placeID);
			_hasUnsavedChanges = true;
		}

		private void CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvPlan.IsCurrentCellDirty)
			{
				// This fires the cell value changed event
				dgvPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private int GetDataGridRowPlaceID(int rowIndex) => (int)(dgvPlan.Rows[rowIndex].Cells[0].Value ?? -1);

		private void Save()
		{
			PlanController.Save(_currentPlanId);
			_hasUnsavedChanges = false;
		}

		private void CreatePlan()
		{
			var plan = PlanController.CreatePlan(dtpDate.Value, (Municipality)cbMunicipalty.SelectedItem);
			_currentPlanId = plan.ID;
			cbStatus.SelectedItem = plan.Statuses;

			dgvPlan.Enabled = true;
			cbStatus.Enabled = true;
			_hasUnsavedChanges = false;
		}
	}
}
