using System;
namespace Avenga.OopAdv.Class08.MoreDelegates
{
    public delegate void SayHello();
    class Program
    {
        public delegate void ShowMessage(string message, string name);
        public delegate int SumDelegate(int num1, int num2);

        static void Main(string[] args)
        {
            //SayHello sayHello = new SayHello(WelcomMessage);
            var example = new Example();
            ShowMessage showMessage = new ShowMessage(example.PrintMessage);
            showMessage("test", "danilo");
        }
    }
}