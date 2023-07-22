using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace オブザーバー
{
    internal static class Program
    {
        internal static WarningTimer WarningTimer { get;}
        = new WarningTimer();

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WarningTimer.Start();
            Application.Run(new MainForm());
        }
    }
}
