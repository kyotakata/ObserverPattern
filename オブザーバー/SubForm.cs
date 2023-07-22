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
    public partial class SubForm : Form, INotify
    {
        public SubForm()
        {
            InitializeComponent();

            this.Disposed += SubForm_Disposed;  // Disposeイベントを追加
            StartPosition = FormStartPosition.CenterScreen;

        }

        /// <summary>
        /// 画面をDisopseする(離れる)時に通る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubForm_Disposed(object sender, EventArgs e)
        {
            Program.WarningTimer.Remove(this);// Actionを抜く
        }

        private void WarningTimer_WarningAction(bool isWarning)
        {
            // コントロールが作成されたスレッド以外のスレッド上で
            // UIスレッドで作成したコントロールにアクセスできない
            // ので、以下をおまじない的に書く
            this.Invoke((Action)delegate ()
            {

                if (isWarning)
                {
                    WarningLabel.Text = "警報";
                    WarningLabel.BackColor = Color.Red;
                }
                else
                {
                    WarningLabel.Text = "正常";
                    WarningLabel.BackColor = Color.Lime;
                }
            });

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Program.WarningTimer.Add(this);
            }
            else
            {
                Program.WarningTimer.Remove(this);
            }
        }

        public void Update(bool isWarning)
        {
            // コントロールが作成されたスレッド以外のスレッド上で
            // UIスレッドで作成したコントロールにアクセスできない
            // ので、以下をおまじない的に書く
            this.Invoke((Action)delegate ()
            {

                if (isWarning)
                {
                    WarningLabel.Text = "警報";
                    WarningLabel.BackColor = Color.Red;
                }
                else
                {
                    WarningLabel.Text = "正常";
                    WarningLabel.BackColor = Color.Lime;
                }
            });

        }
    }
}
