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

        public static event Action<bool> WarningAction;// eventをつけることでdelegateをカプセル化できる。publicで公開はされているが、外部でイベントの登録(+=)と解除(-=)以外はできない。eventをつけると=では入れれない。eventをとると入れれてしまう。

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
                    WarningAction?.Invoke(value);// nullじゃなかったら登録されているイベントにInvoke(通知)する。下と同じ意味。
                    //if (WarningAction != null)
                    //{
                    //    WarningAction.Invoke(value);
                    //}
                }
            }
        }

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
