using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	public partial class RegisterRecordForm : Form
	{
		private int _currentPlanId;
		private bool _hasUnsavedChanges = false;
		private int _selectedRowPlaceIndex = -1;

		private const int PlaceColumnWidth = 200;
		private const int DayColumnWidth = 27;

		public RegisterRecordForm(int planId)
		{
			InitializeComponent();
			_currentPlanId = planId;
			LoadStatusesValues();
			if (planId != -1)
				LoadPlanInfo(planId);
			//if () //TODO: session
			//DisableEditing();
			dgvPlan.Enabled = true;
			InitDataGrid();
		}

		private void InitDataGrid()
		{
			var list11 = new List<string>() { "10", "30", "80", "100" }; //TODO
			var places = new DataGridViewComboBoxColumn
			{
				HeaderText = "Район",
				DataPropertyName = "Place",
				Width = PlaceColumnWidth,
				DataSource = list11,
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
		}

		private void DisableEditing()
		{
			cbStatus.Enabled = false;
			dtpDate.Enabled = false;
			cbMunicipalty.Enabled = false;
		}

		private void LoadStatusesValues()
		{
			//cbStatus.Items = //TODO
		}

		private void LoadPlanInfo(int id)
		{
			var plan = PlanController.GetPlan(id);
			//dtpDate.Value = plan. //TODO
			//cbPlace.SelectedValue = plan.Equals //TODO
			//cbStatus.SelectedIndex = //TODO

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
			if (cbMunicipalty.SelectedIndex != 0 && _currentPlanId == -1)
				CreatePlan();
			else if (_currentPlanId != -1)
				PlanController.SetPlanDate(_currentPlanId, dtpDate.Value);
			_hasUnsavedChanges = true;
		}

		private void OnMunicipalityChanged(object sender, EventArgs e)
		{
			if (dtpDate.Value != DateTime.MinValue && _currentPlanId == -1)
				CreatePlan();
			else if (_currentPlanId != -1)
				PlanController.SetPlanMunicipalty(_currentPlanId, cbMunicipalty.SelectedIndex);
			_hasUnsavedChanges = true;
		}

		private void OnStatusChanged(object sender, EventArgs e)
		{
			PlanController.SetPlanStatus(_currentPlanId, cbStatus.SelectedIndex);
			_hasUnsavedChanges = true;
		}

		private void OnDataGridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			//TODO
			_hasUnsavedChanges = true;
		}

		//private void OnDataGridRowAdded(object sender, DataGridViewRowsAddedEventArgs e)
		//{
		//	//PlanController.AddLocation(_currentPlanId, GetDataGridRowPlaceIndex(e.RowIndex));
		//	//_hasUnsavedChanges = true;
			
		//}

		private void OnDataGridRowRemoving(object sender, DataGridViewRowCancelEventArgs e)
		{
			PlanController.RemoveLocation(_currentPlanId, GetDataGridRowPlaceIndex(e.Row.Index));
			_hasUnsavedChanges = true;
		}

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			if (_currentPlanId == -1)
				return;
			if (_hasUnsavedChanges && MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Предупреждение", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
				OnSave(null, null);
			else
				PlanController.RevertChanges(_currentPlanId);
		}

		private void OnSave(object sender, EventArgs e) => Save();

		//TODO: on comment changed

		private void OnCellEdited(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 0)
				return;
			PlanController.EditPlanPlace(_currentPlanId, _selectedRowPlaceIndex, GetDataGridRowPlaceIndex(e.RowIndex));
			_hasUnsavedChanges = false;
		}

		private void OnRowSelected(object sender, DataGridViewCellEventArgs e) => _selectedRowPlaceIndex = GetDataGridRowPlaceIndex(e.RowIndex);

		private int GetDataGridRowPlaceIndex(int rowIndex)
		{
			var value = dgvPlan.Rows[rowIndex].Cells[0].Value;
			//TODO
			return -1;
		}
		
		private void Save()
		{
			PlanController.Save(_currentPlanId);
			_hasUnsavedChanges = false;
		}

		private void CreatePlan()
		{
			_currentPlanId = PlanController.CreatePlan(dtpDate.Value, cbMunicipalty.SelectedIndex);//TODO
			dgvPlan.Enabled = true;
			cbStatus.Enabled = true;
		}

		private void OnDataGridRowAdded(object sender, DataGridViewRowEventArgs e)
		{
			var cb = new ComboBox();
			cb.Items.AddRange(new object[] { 1, 2 });
			e.Row.Cells[0].Value = cb;
		}
	}
}
