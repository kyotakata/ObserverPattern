using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace オブザーバー
{
    public static class WarningTimer
    {
        private static System.Threading.Timer _timer;

        private static List<INotify> _notifies = new List<INotify>();

        static WarningTimer()
        {
            _timer = new System.Threading.Timer(TimerCallback);
        }

        private static bool _isWarning = false;
        public static bool IsWarning
        {
            get { return _isWarning; }
            private set
            {
                if (_isWarning != value)
                {
                    _isWarning = value;
                    foreach (var notify in _notifies)
                    {
                        notify.Update(value);
                    }
                }
            }
        }

        public static void Add(INotify notify)
        {
            if (!_notifies.Contains(notify))// 同じイベントが登録されないようにする
            {
                _notifies.Add(notify);
            }
        }

        public static void Remove(INotify notify)
        {
            _notifies.Remove(notify);
        }

        public static void Start()
        {
            _timer.Change(0, 5000);
        }

        private static void TimerCallback(object state)
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
