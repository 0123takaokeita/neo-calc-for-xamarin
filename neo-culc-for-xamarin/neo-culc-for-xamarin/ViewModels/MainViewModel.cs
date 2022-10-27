using Xamarin.Forms;
using neo_culc_for_xamarin.Models;

namespace neo_culc_for_xamarin.ViewModels
{
    public interface ICommon
    {
        string Title { get; set; }
        string SubTitle { get; set; }
        string DispText { get; set; }
        string ModeName { get; }
        string SelectValue(string target, string digit);
        void SelectOperator();
        void ClearDisplay();
        void Decision();
        void ChangeMode();
    }

    public class MainViewModel : BaseViewModel
    {
        public ICommon model;
        public Command SelectValue { get; set; }
        public Command SelectOperator { get; set; }
        public Command ClearDisplay { get; set; }
        public Command Decision { get; set; }
        public Command ChangeMode { get; set; }

        public string Title { get => model.Title; set => model.Title = value; }
        public string SubTitle { get => model.SubTitle; set => model.SubTitle = value; }
        public string DispText { get => model.DispText; set => model.DispText = value; }
        public string ModeName { get => model.ModeName; }

        public MainViewModel()
        {
            model = new Calculator();
            SelectValue = new Command(_selectValue);
            SelectOperator = new Command(_selectOpelator);
            ClearDisplay = new Command(_clearDisplay);
            Decision = new Command(_decision);
            ChangeMode = new Command(_changeMode);
        }

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
            DispText = model.SelectValue(DispText, obj.ToString());
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
        /// イコールを押したときにModeに合わせて実行する。
        /// </summary>
        /// <param name="obj"></param>
        private void _decision(object obj)
        {
            _reloadDisplay();
        }

        /// <summary>
        /// Operatorモードの設定を行う。
        /// </summary>
         // <param name="obj"></param>
        private void _selectOpelator(object obj)
        {
            _reloadDisplay();
        }
    }
}
