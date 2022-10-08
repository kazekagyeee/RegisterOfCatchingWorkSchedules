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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddRecord(object sender, EventArgs e)
        {
            new RegisterRecordForm().ShowDialog();
        }
    }
}
