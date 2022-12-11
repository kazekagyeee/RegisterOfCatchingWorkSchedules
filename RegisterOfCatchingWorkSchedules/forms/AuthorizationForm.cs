using System;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
	public partial class AuthorizationForm : Form
	{
		public AuthorizationForm() => InitializeComponent();

		private void OnLogin(object sender, EventArgs e)
		{
			if (UserController.TryLogin(textBox_login.Text, textBox_password.Text))
			{
				MessageBox.Show("Авторизация успешна");
				Close();
			}
			else
			{
				MessageBox.Show("Неверный логин или пароль");
			}
		}
	}
}
