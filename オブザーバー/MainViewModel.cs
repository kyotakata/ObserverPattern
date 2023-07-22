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
    public class MainViewModel : INotifyPropertyChanged, INotify, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        WarningTimerBase _warningTimerBase;
        Dispatcher _dispatcher;

        public MainViewModel(Dispatcher dispatcher, WarningTimerBase warningTimerBase)
        {
            _dispatcher = dispatcher;
            _warningTimerBase = warningTimerBase;
            _warningTimerBase.Add(this);// MainFormをINotifyとして追加する

        }
        public void Dispose()
        {
            _warningTimerBase.Remove(this);
        }

        private string _warningLabelText = "AAA";
        public string WarningLabelText
        {
            get
            {
                return _warningLabelText;
            }
            set
            {
                if (_warningLabelText != value)
                {
                    _warningLabelText = value;
                    if (_dispatcher == null)
                    {
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WarningLabelText"));// イベントハンドラの引数は自分自身と出来事を渡す。Microsoftの設計パターン。
                    }
                    else
                    {
                        // コントロールが作成されたスレッド以外のスレッド上で
                        // UIスレッドで作成したコントロールにアクセスできない
                        // ので、以下をおまじない的に書く
                        // こうすることでUIスレッド上に戻って処理が行われる
                        // Invokeメソッドに渡す引数はdelegate(Actionというパラメータなし戻り値なしのメソッド)です。UIスレッド上に戻りこの処理を実行する。
                        _dispatcher.Invoke((Action)(() =>
                        {
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WarningLabelText"));// イベントハンドラの引数は自分自身と出来事を渡す。Microsoftの設計パターン。
                        }));
                    }
                }
            }
        }

        public void Update(bool isWarning)
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

        }

    }
}
