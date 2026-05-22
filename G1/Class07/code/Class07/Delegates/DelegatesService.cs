namespace Delegates
{
    internal class DelegatesService
    {
        // ===> Delegate is like a type of a method — it lets you store a method, with the specified parameters and return, inside a variable

        private delegate double CalculationDelegate(int num1, int num2);
        private delegate void SayDelegate(string text);

        private void SayHello(string text)
        {
            Console.WriteLine(text);
        }

        private void SayWhatever(string whatever, SayDelegate sayMethod)
        {
            sayMethod(whatever);
        }

        private double Calculate(int num1, int num2, CalculationDelegate operation)
        {
            return operation(num1, num2);
        }

        //private double Calculate(int num1, int num2, Func<int, int, double> operation)
        //{
        //    return operation(num1, num2);
        //}

        private double Product(int num1, int num2)
        {
            return num1 * num2;
        }
        

        public void Run()
        {
            Console.WriteLine("Hello, World!");

            Func<int, int, int> subtractFunc = (num1, num2) => num1 - num2;
            Console.WriteLine(subtractFunc(10, 20));

            Action<string, ConsoleColor> printInColor = (text, color) =>
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ResetColor();
            };
            printInColor("This is green", ConsoleColor.Green);

            CalculationDelegate subtract = (num1, num2) => num1 - num2;
            Console.WriteLine(subtract(20, 5));

            SayDelegate sayHello = new SayDelegate(word => Console.WriteLine(word));
            sayHello("Hello");

            SayDelegate sayHelloAgain = new SayDelegate(SayHello);

            SayWhatever("WHATEVER 1!", sayHello);
            SayWhatever("WHATEVER 2!", SayHello);
            SayWhatever("WHATEVER 3!", text => Console.WriteLine(text));
            SayWhatever("WHATEVER 4!", text => printInColor(text, ConsoleColor.Red));
            //SayWhatever("WHATEVER !", (num1, num2) => num1 + num2); // ERROR


            printInColor("\n============ Calculator Example ============\n", ConsoleColor.Magenta);

            double sumResult = Calculate(10, 20, (num1, num2) => num1 + num2);
            printInColor("The sum result is " + sumResult, ConsoleColor.Yellow);

            double subtractResult = Calculate(10, 20, subtract);
            printInColor("The subtract result is " + subtractResult, ConsoleColor.Cyan);

            double productResult = Calculate(10, 20, Product);
            printInColor("The product result is " + productResult, ConsoleColor.DarkRed);
        }
    }
}
