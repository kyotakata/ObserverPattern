using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace オブザーバー
{
    internal class MainViewModel : INotifyPropertyChanged, INotify, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Dispatcher _dispatcher;

        public MainViewModel(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            WarningTimer.Add(this);// MainFormをINotifyとして追加する

        }
        public void Dispose()
        {
            WarningTimer.Remove(this);
        }

        private string _warningLabelText = string.Empty;
        public string WarningLabelText
        {
            get
            {
                return _warningLabelText;
            }
            set
            {
                if(_warningLabelText != value)
                {
                    _warningLabelText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WarningLabelText"));// イベントハンドラの引数は自分自身と出来事を渡す。Microsoftの設計パターン。
                }
            }
        }

        public void Update(bool isWarning)
        {
            // コントロールが作成されたスレッド以外のスレッド上で
            // UIスレッドで作成したコントロールにアクセスできない
            // ので、以下をおまじない的に書く
            // こうすることでUIスレッド上に戻って処理が行われる
            _dispatcher.Invoke((Action)delegate ()
            {
                if (isWarning)
                {
                    WarningLabelText = "警報";
                    //WarningLabel.BackColor = Color.Red;
                }
                else
                {
                    WarningLabelText = "正常";
                    //WarningLabel.BackColor = Color.Lime;
                }
            });

        }

    }
}
