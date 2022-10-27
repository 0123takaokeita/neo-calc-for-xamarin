using neo_culc_for_xamarin.ViewModels;

namespace neo_culc_for_xamarin.Models
{

    public class Stock : ICommon
    {
        public string Title { get; set; } = "株価取得";
        public string SubTitle { get; set; } = "株価を取得できます。";
        public string DispText { get; set; } = "コードを入力してください。";
        public string ModeName{ get; set; } = "Stock";
        private int DisplayLimit = 12;

        /// <summary>
        /// 入力された文字をDisplayに反映する。
        /// 有効な場合は変数に値を保持する。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public string SelectValue(string target, string digit)
        {
            if (target.Length + 1 > DisplayLimit) return target;
            if (target.Contains(".") && digit == ".") return target; // 入力を反映しない。 小数点モード
            target = (target == "0" && digit != ".") ? digit : target + digit; // 整数モード

            // TODO: データを保持する変数を振り分ける。
            return target;
        }

        public void SelectOperator() { }
        public void ClearDisplay() { }
        public void Decision() { }
        public void ChangeMode() { }
    }

}
