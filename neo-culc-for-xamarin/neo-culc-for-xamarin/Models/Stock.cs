using neo_culc_for_xamarin.ViewModels;

namespace neo_culc_for_xamarin.Models
{
    public class Stock : ICommon
    {
        public string Title { get; } = "株価取得";
        public string SubTitle { get; set; } = "株価を取得できます。";
        public string DispText { get; set; } = "コードを入力してください。";
        public ModeKind ModeName { get; } = ModeKind.STOCK;
        private int DisplayLimit = 12;

        /// <summary>
        /// 入力された文字をDisplayに反映する。
        /// 有効な場合は変数に値を保持する。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public void SelectValue(string digit)
        {
            /* if (DispText.Length + 1 > DisplayLimit) ; */
            /* if (DispText.Contains(".") && digit == ".") return DispText; // 入力を反映しない。 小数点モード */
            /* DispText = (DispText == "0" && digit != ".") ? digit : DispText + digit; // 整数モード */
        }

        /// <summary>
        /// 入力されたOperetorに合わせてOperatorStateを更新する。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public void SelectOperator(string ope) { }
        public void Decision() {  }
        public string ReverseSign(string txt) { return ""; }
    }

}
