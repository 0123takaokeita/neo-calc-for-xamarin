using neo_culc_for_xamarin.ViewModels;

namespace neo_culc_for_xamarin.Models
{
    public class Calculator : ICommon
    {
        public string Title { get; } = "電卓";
        public string SubTitle { get; set; } = "計算を開始できます";
        public string DispText { get; set; } = "0";
        public ModeKind ModeName { get; } = ModeKind.CALCULATOR;

        private decimal FirstNum;
        private decimal SecondNum;
        private int DisplayLimit = 11;
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
        /// </summary>
        /// <param name="target"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public void SelectValue(string digit)
        {
            if (DisplayState == DisplayStateKind.CLEAR) DispText = "0";
            DispText = _appendDigit(DispText, digit);
            if (!DispText.Contains(".")) DispText = _convertNum(DispText);
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
            if (DispText == "E") return;
            decimal result = 0;
            if (SecondNum == 0)
            {
                SecondNum = decimal.Parse(DispText);
                result = _execCalc(FirstNum, SecondNum);
            }
            else
            {
                result = _execCalc(decimal.Parse(DispText), SecondNum);
            }

            DispText = _convertNum(result.ToString());
            FirstNum = 0;
            DisplayState = DisplayStateKind.CLEAR;
            if (DispText.Length >= 12)
            {
                DispText = "E";
                SecondNum = 0;
            }
        }

        /// <summary>
        /// 文字列の数字の符号を付け替える
        /// </summary>
        /// <param name="txt"></param>
        public string ReverseSign(string txt)
        {
            return $"{-decimal.Parse(txt)}";
        }


        /// <summary>
        /// 文字列をカンマ区切りでフォーマットする。
        /// </summary>
        /// <param name="num"></param>
        private string _convertNum(string num)
        {
            return string.Format("{0:#,0}", decimal.Parse(num));
        }

        /// <summary>
        /// firstOperand secondOperand の計算結果を返す。
        /// </summary>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <returns></returns>
        private decimal _execCalc(decimal firstOperand, decimal secondOperand)
        {
            decimal result = secondOperand;
            if (OperatorState == OperatorStateKind.addition) result = firstOperand + secondOperand;
            if (OperatorState == OperatorStateKind.substraction) result = firstOperand - secondOperand;
            if (OperatorState == OperatorStateKind.multiplication) result = firstOperand * secondOperand;
            if (OperatorState == OperatorStateKind.division) result = firstOperand / secondOperand;
            return result;
        }

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
