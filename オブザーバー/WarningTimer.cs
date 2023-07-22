using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace オブザーバー
{
    public class WarningTimer : WarningTimerBase
    {
        private System.Threading.Timer _timer;


        public WarningTimer()
        {
            _timer = new System.Threading.Timer(TimerCallback);
        }


        public void Start()
        {
            _timer.Change(0, 5000);
        }

        private void TimerCallback(object state)
        {
            var lines = System.IO.File.ReadAllLines("warning.txt");
            if (lines.Length > 0)
            {
                IsWarning = lines[0] == "1";
                return;
            }

            IsWarning = false;
        }
    }
}
