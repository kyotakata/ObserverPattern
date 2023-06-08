using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace オブザーバー
{
    public partial class MainForm : Form
    {
        private MainViewModel _vm
            = new MainViewModel(Dispatcher.CurrentDispatcher);

        public MainForm()
        {
            InitializeComponent();

            this.Disposed += MainForm_Disposed;  // Disposeイベントを追加
            StartPosition = FormStartPosition.CenterScreen;


            WarningLabel.DataBindings.Add("Text", _vm, nameof(_vm.WarningLabelText));// ここでフレームワーク内部でPropertyChangedにVewModelのプロパティ名に応じて、各コントロールの値を変えるイベントが登録される
        }

        /// <summary>
        /// 画面をDisopseする(離れる)時に通る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Disposed(object sender, EventArgs e)
        {
            _vm?.Dispose();
        }


        private void SubButton_Click(object sender, EventArgs e)
        {
            var f = new SubForm();
            f.Show();
        }


    }
}
