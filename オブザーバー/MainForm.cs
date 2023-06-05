using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace オブザーバー
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            timer1.Interval = 5000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(WarningTimer.IsWarning)
            {
                WarningLabel.Text = "警報";
                WarningLabel.BackColor = Color.Red;
            }
            else
            {
                WarningLabel.Text = "正常";
                WarningLabel.BackColor = Color.Lime;
            }
        }

        private void SubButton_Click(object sender, EventArgs e)
        {
            var f = new SubForm();
            f.Show();
        }
    }
}
