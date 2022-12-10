using Equin.ApplicationFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	public partial class RegisterRecordForm : Form
	{
		private int _currentPlanId;
		private bool _hasUnsavedChanges = false;
		private Places _selectedRowPlace;

		private bool _isInitialized = false;

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
			InitComboboxes();
			InitDataGrid();

			_isInitialized = true;
		}

		private void InitComboboxes()
		{
			Program.DBContext.Municipality.Load();
			cbMunicipalty.DataSource = Program.DBContext.Municipality.Local.ToBindingList(); //TODO
			cbMunicipalty.ValueMember = "ID";
			cbMunicipalty.DisplayMember = "MunicipalityName";

			Program.DBContext.Statuses.Load();
			cbStatus.DataSource = Program.DBContext.Statuses.Local.ToBindingList(); //TODO
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
				DataSource = new BindingListView<Places>(Program.DBContext.Places.ToList()), //TODO
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
			//TODO: clear table, show message
			if (!_isInitialized)
				return;
			if (cbMunicipalty.SelectedIndex != 0 && _currentPlanId == -1)
				CreatePlan();
			else if (_currentPlanId != -1)
				PlanController.SetPlanDate(_currentPlanId, dtpDate.Value);
			_hasUnsavedChanges = true;
		}

		private void OnMunicipalityChanged(object sender, EventArgs e)
		{
			//TODO: clear table, show message
			if (!_isInitialized)
				return;
			if (dtpDate.Value != DateTime.MinValue && _currentPlanId == -1)
				CreatePlan();
			else if (_currentPlanId != -1)
				PlanController.SetPlanMunicipalty(_currentPlanId, (Municipality)cbMunicipalty.SelectedItem);
			((dgvPlan.Columns[0] as DataGridViewComboBoxColumn).DataSource as BindingListView<Places>).ApplyFilter(x => x.MunicipalityID == (cbMunicipalty.SelectedItem as Municipality).ID);
			_hasUnsavedChanges = true;
		}

		private void OnStatusChanged(object sender, EventArgs e)
		{
			if (!_isInitialized)
				return;
			PlanController.SetPlanStatus(_currentPlanId, (Statuses)cbStatus.SelectedItem);
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
			PlanController.RemovePlace(_currentPlanId, GetDataGridRowPlace(e.Row.Index));
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
			PlanController.EditPlace(_currentPlanId, _selectedRowPlace, GetDataGridRowPlace(e.RowIndex));
			_hasUnsavedChanges = false;
		}

		private void OnRowSelected(object sender, DataGridViewCellEventArgs e) => _selectedRowPlace = GetDataGridRowPlace(e.RowIndex);

		private Places GetDataGridRowPlace(int rowIndex) =>  (Places)dgvPlan.Rows[rowIndex].Cells[0].Value;

		private void Save()
		{
			PlanController.Save(_currentPlanId);
			_hasUnsavedChanges = false;
		}

		private void CreatePlan()
		{
			_currentPlanId = PlanController.CreatePlan(dtpDate.Value, (Municipality)cbMunicipalty.SelectedItem);//TODO
			//TODO: update status
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
