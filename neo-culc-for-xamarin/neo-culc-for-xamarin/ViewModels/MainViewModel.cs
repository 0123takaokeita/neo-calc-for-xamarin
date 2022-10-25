using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using neo_culc_for_xamarin.Models;
using neo_culc_for_xamarin.ViewModels;

namespace neo_culc_for_xamarin.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private Calculator model;
        public Command AddNumber { get; }
        public Command ClearDisplay { get; }

        public MainViewModel()
        {
            this.model = new Calculator();
            this.Title = "Calculator";
            this.SubTitle = "sub disp area";
            this.DispText = "0";
            this.AddNumber = new Command(ExcecuteAddNumber);
            this.ClearDisplay = new Command(ExcecuteClearDisplay);
        }

        private int _modeState
        {
            get => model.ModeState;
            set => model.ModeState = value;
        }
        private int _operatorState
        {
            get => model.OperatorState;
            set => model.OperatorState = value;
        }
        private double _targetNum
        {
            get => model.TargetNum;
            set => model.TargetNum = value;
        }
        private double _senderNum
        {
            get => model.SenderNum;
            set => model.SenderNum = value;
        }

        public string DispText
        {
            get => model.DispText;
            set => model.DispText = value;
            /* set => SetProperty(ref model.DispText, value); */
        }

        private void ExcecuteAddNumber(object param)
        {
            string digit = param.ToString();
            if (DispText.Contains(".") && digit == ".") return; // 入力を反映しない。 小数点モード
            DispText = (DispText == "0" && digit != ".") ? digit : DispText + digit; // 整数モード

            OnPropertyChanged("DispText");  // ディスプレイを view に反映させるために必須。更新の通知。
        }

        private void ExcecuteClearDisplay()
        {
            model.DispText = "0";
            OnPropertyChanged("DispText");
        }

        private void ExcecuteCalculate()
        {
        }
    }
}



/* public event PropertyChangedEventHandler PropertyChanged; */
/* private string _name; */
/* public string name */
/* { */
/* get */
/* { */
/*     return this._name; */
/* } */
/* set */
/* { */
/*     this.PropertyChanged(this, new PropertyChangedEventArgs("name")); */
/*     this._name = value; */
/* } */

/*     } */
/*     public MainPage() */
/*     { */
/*         InitializeComponent(); */
/*         this.BindingContext = this; */
/*     } */

/*     //テキストに入力された値を、nameに代入する。 */
/*     private void Button_Clicked(object sender, EventArgs e) */
/*     { */
/*          this.name = entry.Text; */
/*     } */
/* } */



/* /// <summary> */
/* /// </summary> */
/* /// <param name="sender"></param> */
/* /// <param name="e"></param> */
/* void onSelectNumber(object sender, EventArgs e) */
/* { */
/*     string inputDigit = ((Xamarin.Forms.Button)sender).Text; */
/*     Title = "1"; */

/*     // 入力された数字をディスプレイにバインドする。 */

/*     // disp が 0 のときは削除する */
/*     /1* if (this.MainDisp.Text == "0" || modeState < 0) *1/ */
/*     /1* { *1/ */
/*     /1*     this.MainDisp.Text = ""; *1/ */
/*     /1*     if (modeState < 0) modeState *= -1; *1/ */
/*     /1* } *1/ */

/*     /1* this.MainDisp.Text += inputDigit; *1/ */

/*     /1* double parsedNum; *1/ */
/*     /1* if (double.TryParse(this.MainDisp.Text, out parsedNum)) *1/ */
/*     /1* { *1/ */
/*     /1*     this.MainDisp.Text = parsedNum.ToString("N0"); *1/ */
/*     /1*     if (modeState == 1) *1/ */
/*     /1*     { *1/ */
/*     /1*         targetNum = parsedNum; *1/ */
/*     /1*     } *1/ */
/*     /1*     else *1/ */
/*     /1*     { *1/ */
/*     /1*         senderNum = parsedNum; *1/ */
/*     /1*     } *1/ */
/*     /1* } *1/ */
/* } */

/* /// <summary> */
/* /// </summary> */
/* /// <param name="sender"></param> */
/* /// <param name="e"></param> */
/* void onSelectOperator(object sender, EventArgs e) */
/* { */
/*     /1* if (senderNum != 0) reloadTargetNum(); *1/ */
/*     /1* modeState = -2; *1/ */
/*     /1* string inputOperator = ((Xamarin.Forms.Button)sender).Text; *1/ */
/*     /1* operatorState = 1; *1/ */
/* } */

/* /// <summary> */
/* /// </summary> */
/* /// <param name="sender"></param> */
/* /// <param name="e"></param> */
/* void onCalclate(System.Object sender, System.EventArgs e) */
/* { */
/*     /1* if (senderNum == 0) senderNum = targetNum; *1/ */
/*     /1* reloadTargetNum(); *1/ */
/*     /1* modeState = -1; *1/ */
/* } */

/* /// <summary> */
/* /// 変数設定をクリア */
/* /// </summary> */
/* /// <param name="sender"></param> */
/* /// <param name="e"></param> */
/* void onClearResult(object sender, EventArgs e) */
/* { */
/*     /1* targetNum = 0; *1/ */
/*     /1* senderNum = 0; *1/ */
/*     /1* modeState = 1; *1/ */
/*     /1* MainDisp.Text = "0"; *1/ */
/* } */

/* void reloadTargetNum() */
/* { */
/*     /1* var result = targetNum + senderNum; *1/ */
/*     /1* this.MainDisp.Text = $"{result}"; *1/ */
/*     /1* targetNum = result; *1/ */
/* } */
