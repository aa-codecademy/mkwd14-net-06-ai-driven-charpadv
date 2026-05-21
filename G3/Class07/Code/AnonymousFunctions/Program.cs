//Lambda expressions

using System.Globalization;

List<string> names = new List<string> { "Bob", "Petko", "Trajko", "Nikola", "Marko" };

string foundBob = names.FirstOrDefault(x => x.ToLower() == "Bob".ToLower());

//Func => used to store methods that return a value and can have params or no params
//we are reading from left to right (Func<int, string, bool> that means that we have a function (method) with two params and a return type
//The return type will be bool. The first param is int. The second param is string. If there is only one data type then that one is the return type

//Func ALWAYS has a return type. This is a function that has no params but has a return type int
Func<int> sumOfTwoAndFive = () => 2 + 5;

Console.WriteLine(sumOfTwoAndFive());

//we are storing anon method that takes one param of type List<string> and returns a bool
                                              //params  => method body
Func<List<string>, bool> checkIfListIsEmpty = (list) =>  list.Count == 0;
bool isEmpty = checkIfListIsEmpty(names); //we use the name that we stored the anon method in to call the method

//two params that are int and a return type that is also int
Func<int, int, int> sum = (x, y) => x + y;
Console.WriteLine(sum(3,4));

//five int params and a return type int (that's why we have 6 ints here)
//we need to write as many data types as we have params +1 for the return type
Func<int, int, int, int, int, int> sumofInts = (a, b, c, d, e) => a + b + c + d + e;
int Sum(int a, int b, int c, int d, int e)
{
	return a + b + c + d + e;
}

//two params int and a return type bool
//when we want to have many lines of code in the body of the anon method, we use {} for the method body
Func<int, int, bool> isFirstNumberLarger = (x, y) =>
{
	if (x > y)
	{
		return true;
	}
	else
	{
		return false;
	}
};

//one param int and return type bool
//when we have only one param, we can omit the () for the param
Func<int, bool> checkEven = x => x % 2 == 0;

List<int> ints = new List<int>() { 2, 3, 5, 6, 7, 8 };
List<int> secondInts = new List<int>() { 3, 5, 7, 8, 9 };

//checkEven will be called for each item of the list od ints
List<int> evenNumbers = ints.Where(checkEven).ToList();

//we can reuse the checkEven method, so that we don't have to write the check logic each time
List<int> evenNumbersFromSecondInts = secondInts.Where(checkEven).ToList();

//one param string and return type bool
Func<string, bool> startsWithB = x => x.StartsWith("B");
Console.WriteLine(startsWithB("Bob")); 
List<string> namesStartingWithB = names.Where(startsWithB).ToList();

//Action - Action is ALWAYS VOID

//one param that is int - no return type
Action<int> printNumber = x => Console.WriteLine(x);

//no params and because it is Action it is void
Action sayHello = () => Console.WriteLine("Hello");

//when we have multi line code in the method body we use {}
//one param - string
Action<string> printRed = x =>
{
	Console.ForegroundColor = ConsoleColor.Red; //we set the color that is shown in the console to be red
	Console.WriteLine(x); //this one param will be printed in red
	Console.ResetColor(); //we reset the color back to default
};

printRed("hello G3");

//two params - first one is string, second one is ConsoleColor
Action<string, ConsoleColor> printColor = (message, color) =>
{
	Console.ForegroundColor = color;
	Console.WriteLine(message);
	Console.ResetColor();
};

printColor("We are learning anonymous methods", ConsoleColor.Magenta);