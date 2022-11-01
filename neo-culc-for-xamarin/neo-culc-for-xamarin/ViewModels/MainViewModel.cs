using Xamarin.Forms;
using neo_culc_for_xamarin.Models;

namespace neo_culc_for_xamarin.ViewModels
{
    public interface ICommon
    {
        string Title { get; }
        string SubTitle { get; set; }
        string DispText { get; set; }
        ModeKind ModeName { get; }
        void SelectValue(string digit);
        void SelectOperator(string ope);
        void Decision();
        string ReverseSign(string txt);
    }

    /// <summary>
    /// アプリのMode一覧
    /// </summary>
    public enum ModeKind
    {
        CALCULATOR,
        STOCK,
    };

    /// <summary>
    /// 画面へのプロパティ変更通知を行う。変更は各Modelに任せる。
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        public ICommon model;
        public Command SelectValue { get; set; }
        public Command SelectOperator { get; set; }
        public Command ClearDisplay { get; set; }
        public Command Decision { get; set; }
        public Command ChangeMode { get; set; }
        public Command PushReverse { get; }

        // 委譲関係で Title の管理を任せている。
        public string Title { get => model.Title; }
        public string SubTitle { get => model.SubTitle; set => model.SubTitle = value; }
        public string DispText { get => model.DispText; set => model.DispText = value; }
        public ModeKind ModeName { get => model.ModeName; }

        /// <summary>
        /// コンストラクタ
        /// ここで作成しているもののみ View側で使用できる。
        /// </summary>
        public MainViewModel()
        {
            model = new Calculator();
            SelectValue = new Command(_selectValue);
            SelectOperator = new Command(_selectOpelator);
            ClearDisplay = new Command(_clearDisplay);
            Decision = new Command(_decision);
            ChangeMode = new Command(_changeMode);
            PushReverse = new Command(_pushReverse);
        }

        /// <summary>
        /// プロパティの更新を行う。
        /// </summary>
        private void _reloadDisplay()
        {
            OnPropertyChanged("Title");
            OnPropertyChanged("DispText");
            OnPropertyChanged("SubTitle");
        }

        /// <summary>
        /// アプリのモード変更を行う。
        /// </summary>
        /// <param name="obj"></param>
        private void _changeMode(object obj)
        {
            switch (obj)
            {
                case ("Calculator"):
                    model = new Calculator();
                    break;
                case ("Stock"):
                    model = new Stock();
                    break;
            }
            _reloadDisplay();
        }

        /// <summary>
        /// 入力の処理を画面に反映する。
        /// </summary>
        /// <param name="obj"></param>
        private void _selectValue(object obj)
        {
            model.SelectValue(obj.ToString());
            OnPropertyChanged("DispText");
        }

        /// <summary>
        /// ディスプレイの情報をクリアする。
        /// TODO: プライベートメンバーも初期化したいのでインスタンスを作りなおすことになる。
        /// </summary>
        /// <param name="obj"></param>
        private void _clearDisplay(object obj)
        {
            switch (ModeName)
            {
                case (ModeKind.CALCULATOR):
                    model = new Calculator();
                    break;
                case (ModeKind.STOCK):
                    model = new Stock();
                    break;
            }
            _reloadDisplay();
        }

        /// <summary>
        /// イコールを押したときにModeに合わせて実行する。
        /// </summary>
        /// <param name="obj"></param>
        private void _decision(object obj)
        {
            model.Decision();
            _reloadDisplay();
        }

        /// <summary>
        /// Operatorモードの設定を行う。
        /// </summary>
         // <param name="obj"></param>
        private void _selectOpelator(object obj)
        {
            model.SelectOperator(obj.ToString());
            _reloadDisplay();
        }

        /// <summary>
        /// +/- ボタンを押した場合に対応するメソッドを呼び出す。
        /// </summary>
        /// <param name="obj"></param>
        private void _pushReverse(object obj)
        {
            DispText = model.ReverseSign(DispText);
            _reloadDisplay();
        }
    }
}
