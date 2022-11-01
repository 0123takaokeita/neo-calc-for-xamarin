using neo_culc_for_xamarin.ViewModels;

namespace neo_culc_for_xamarin.Models
{

    /* public class Calculator : ICommon, ICommand */
    public class Calculator : ICommon
    {
        public string Title { get; set; } = "電卓";
        public string SubTitle { get; set; } = "計算を開始できます";
        public string DispText { get; set; } = "0";
        public ModeKind ModeName { get; } = ModeKind.CALCULATOR;

        private double FirstNum { get; set; }
        private double SecondNum { get; set; }
        private int DisplayLimit = 12;
        private DisplayStateKind DisplayState = DisplayStateKind.INPUT;
        private OperatorStateKind OperatorState = OperatorStateKind.none;

        /// <summary>
        /// 計算モードの管理
        /// </summary>
        public enum OperatorStateKind
        {
            none,
            addition,
            substraction,
            multiplication,
            division,
        };

        /// <summary>
        /// 画面を初期化するかどうかの状態
        /// </summary>
        public enum DisplayStateKind
        {
            INPUT,
            CLEAR,
        };

        /// <summary>
        /// 入力された文字をDisplayに反映する。
        /// 有効な場合は変数に値を保持する。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public void SelectValue(string digit)
        {
            if (DisplayState == DisplayStateKind.CLEAR) DispText = "0";
            DispText = _appendDigit(DispText, digit);
            DisplayState = DisplayStateKind.INPUT;
        }

        /// <summary>
        /// 入力されたオペレーターをもとにOperatorStateを更新する。
        /// </summary>
        /// <param name="ope">オペレーター</param>
        /// <returns></returns>
        public void SelectOperator(string ope)
        {
            FirstNum = decimal.Parse(DispText);
            SecondNum = 0;

            if (ope == "+") OperatorState = OperatorStateKind.addition;
            if (ope == "-") OperatorState = OperatorStateKind.substraction;
            if (ope == "*") OperatorState = OperatorStateKind.multiplication;
            if (ope == "÷") OperatorState = OperatorStateKind.division;

            SubTitle = OperatorState.ToString();
            DisplayState = DisplayStateKind.CLEAR;
        }

        /// <summary>
        /// 渡されたオペレーターの状態に合わせた計算結果に更新
        /// </summary>
        /// <returns name="result">計算結果</returns>
        public void Decision()
        {
            //TODO: 計算結果が桁あふれの場合を考慮していない。
            //TODO: format を実施できていない。
            decimal result = 0;
            if (SecondNum == 0)
            {
                SecondNum = decimal.Parse(DispText);
                result = _execCalc(FirstNum, SecondNum, OperatorState);
            }
            else
            {
                result = _execCalc(decimal.Parse(DispText), SecondNum, OperatorState);
            }

            // TODO: データを保持する変数を振り分ける。

            return target;
        }

        public void SelectOperator() { }
        public void ClearDisplay() { }
        public void Decision() { }
        public void ChangeMode() { }
        /// <summary>
        /// firstOperand secondOperand の計算結果を返す。
        /// </summary>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private decimal _execCalc(decimal firstOperand, decimal secondOperand, OperatorStateKind mode)
        {
            decimal result = secondOperand;
            if (mode == OperatorStateKind.addition) result = firstOperand + secondOperand;
            if (mode == OperatorStateKind.substraction) result = firstOperand - secondOperand;
            if (mode == OperatorStateKind.multiplication) result = firstOperand * secondOperand;
            if (mode == OperatorStateKind.division) result = firstOperand / secondOperand;
            return result;
        }

        public void ReverseSign() {
            DispText = (-decimal.Parse(DispText)).ToString();
        /// <summary>
        /// 入力された文字を追加する。
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="dig"></param>
        /// <returns>txt</returns>
        private string _appendDigit(string txt, string dig)
        {
            if ((txt.Contains(".") && dig == ".") || (txt.Length + 1 > DisplayLimit)) return txt;
            txt = (txt == "0" && dig != ".") ? dig : txt + dig;
            return txt;
        }
    }

}
