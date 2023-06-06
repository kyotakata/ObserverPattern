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

            this.Disposed += MainForm_Disposed;  // Disposeイベントを追加
            StartPosition = FormStartPosition.CenterScreen;

            //WarningTimer.WarningAction += WarningTimer_WarningAction;
            WarningTimer.Add(WarningTimer_WarningAction);
        }

        /// <summary>
        /// 画面をDisopseする(離れる)時に通る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Disposed(object sender, EventArgs e)
        {
            //WarningTimer.WarningAction -= WarningTimer_WarningAction;// Actionを抜く
            WarningTimer.Remove(WarningTimer_WarningAction);// Actionを抜く
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


        private void SubButton_Click(object sender, EventArgs e)
        {
            var f = new SubForm();
            f.Show();
        }
    }
}
