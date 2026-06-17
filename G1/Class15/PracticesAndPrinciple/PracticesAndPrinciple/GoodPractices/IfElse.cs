using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesAndPrinciple.GoodPractices
{
    internal class IfElse
    {
        public void CheckTwoNumbers(int numberOne, int numberTwo)
        {
            //BAD EXAMPLE:
            if (numberOne <= 100 && numberTwo <= 100)
            {
                if (numberOne % 2 == 0 && numberTwo % 2 == 0)
                {
                    if (numberOne > 0 && numberTwo > 0)
                    {
                        if (numberOne == numberTwo)
                        {
                            Console.WriteLine("The numbers are equal.");
                        }
                        else
                        {
                            Console.WriteLine("The numbers are not equal.");
                        }
                    }
                }
            }


            //GOOD EXAMPLE:
            if ((numberOne > 100 || numberOne < 0) || (numberTwo > 100 || numberTwo < 0)) return;
            if (numberOne % 2 != 0 && numberTwo % 2 != 0) return;
            if(numberOne != numberTwo) Console.WriteLine("The numbers are not equal.");
            Console.WriteLine("The numbers are equal.");
            //if (numberOne == numberTwo)
            //{
            //    Console.WriteLine("The numbers are equal.");
            //}
            //else
            //{
            //    Console.WriteLine("The numbers are not equal.");
            //}
        }
    }
}
