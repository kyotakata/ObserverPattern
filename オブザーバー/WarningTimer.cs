using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace オブザーバー
{
    public static class WarningTimer
    {
        private static System.Threading.Timer _timer;
        static WarningTimer()
        {
            _timer = new System.Threading.Timer(TimerCallback);
        }

        public static bool IsWarning { get; private set; }

        public static void Start()
        {
            _timer.Change(0, 5000);
        }

        private static void TimerCallback(object state)
        {
            var lines = System.IO.File.ReadAllLines("warning.txt");
            if(lines.Length > 0)
            {
                IsWarning = lines[0] == "1";
                return;
            }

            IsWarning = false;
        }
    }
}
