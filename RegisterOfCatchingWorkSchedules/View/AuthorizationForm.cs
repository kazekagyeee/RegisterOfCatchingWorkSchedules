using System;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules.View
{
	public partial class AuthorizationForm : Form
	{
		private bool _isLoggedIn = false;

		public AuthorizationForm() => InitializeComponent();

		private void OnLogin(object sender, EventArgs e)
		{
			_isLoggedIn = UserController.TryLogin(textBox_login.Text, textBox_password.Text);
			if (_isLoggedIn)
			{
				//MessageBox.Show("Авторизация успешна");
				Close();
			}
			else
			{
				MessageBox.Show("Неверный логин или пароль");
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (_isLoggedIn)
				base.OnFormClosing(e);
			else
				Application.Exit();
		}
	}
}
