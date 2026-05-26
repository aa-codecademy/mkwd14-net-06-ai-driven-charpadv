using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avenga.OopAdv.Class08.MoreDelegates
{
    public class Example
    {
        public void WelcomMessage()
        {
            Console.WriteLine("Welcome to events and delegates");
        }
        public void PrintMessage(string message, string name)
        {
            Console.WriteLine($"{message}: {name}");
        }
        public int SumOfTwoNumbers(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
