using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterOfCatchingWorkSchedules
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            if (userController.TryLogin(textBox_login.Text, textBox_password.Text))
            {
                MessageBox.Show("Logged in");
            }
        }
    }
}
