namespace neo_culc_for_xamarin.Models

{
    public class Calculator
    {
        public int ModeState { get; set; }
        public int OperatorState { get; set; }
        public double TargetNum { get; set; }
        public double SenderNum { get; set; }
        public string DispText { get; set; }
    }
}
