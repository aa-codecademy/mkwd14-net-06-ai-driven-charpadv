// See https://aka.ms/new-console-template for more information
using AnonymousMethods.Models;

Console.WriteLine("Hello, World!");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n================== ANONYMOUS METHODS ==================\n");
Console.ResetColor();

List<string> names = ["Alice", "Bob", "Charlie", "John", "Anna"];
List<string> empty = [];

// ===> One line lambda expression
string johnName = names.Find(name => name == "John")!;

// Lambda expression (arrow function): name => name == "John"
// => anonymous method with one parameter (*name*) and return value of type bool (*name == "John"* returns bool)

//foreach (var name in names)
//{
//    if (name == "John")
//    {
//        return true;
//    }
//}

// ===> Multiple lines lambda expression
string? john2Name = names.Find(name =>
{
    if (name == "John")
    {
        return true;
    }
    return false;
});

// in JavaScript
// const sum = (num1, num2) => num1 + num2;
// sum(10, 20) // 30

// parameter 1 => int
// parameter 2 => int
// return => int


// var sum = (num1, num2) => num2 + num2;


#region Func

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\n================== Func ==================\n");
Console.ResetColor();
// Func => type of delegate 
// => defines the type of a method (what type and how many parameters will it have and what is the return type)
// => always has a return value ! (the type of the return value is always the last type in the < > brackets)

// ===> Example of a Func with 2 parameters 
Func<int, int, int> sum = (num1, num2) => num1 + num2;
int sumResult = sum(10, 20);
Console.WriteLine(sumResult);

// ===> Example of a Func with no parameters
// bool => return value
Func<bool> isNamesEmpty = () => names.Count == 0;
Console.WriteLine("Is list empty " + isNamesEmpty());

// ===> Exampe of a Func with 1 paramter
Func<List<string>, bool> isListEmpty = list => list.Count == 0;
Console.WriteLine("The list names is " + isListEmpty(names));
Console.WriteLine("The list empty is " + isListEmpty(empty));

// ===> Example of a Func with 2 parameters ints and return type bool
Func<int, int, bool> isLarger = (int num1, int num2) =>
{
    if (num1 > num2)
    {
        return true;
    }
    return false;
};

// ===> Example of a Func with 4 parameters
Func<int, string, double, bool, string> getUserInfo = (id, name, salary, isActive) =>
{
    //return true; // ERROR -> the return type must be string
    return $"ID {id}, Name: {name}, Salary: {salary}, Is Active : {(isActive ? "Yes" : "No")}";
};

string userInfo = getUserInfo(1, "Bob", 3444.33, true);
Console.WriteLine(userInfo);

// ===> Example of a Func that uses class as type
Func<Person, string> getPersonName = person =>
{
    return person.Name;
};

Person bob = new Person { Name = "Bob" };
Console.WriteLine(getPersonName(bob));

// Func<void> printHello = () => Console.WriteLine("Hello"); // ERROR!
// NOTE: Func must have a return value, it cannot be void !!!

#endregion


#region Action

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n================== Action ==================\n");
Console.ResetColor();
// Action is also delegate that is always void !

// Example of an action without parameters
Action printHello = () => Console.WriteLine("Hello");
printHello();

Action<string> printRed = word =>
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(word);
    Console.ResetColor();
    // return word;
};

printRed("Something went wrong!");

Action<string, ConsoleColor> printInColor = (text, color) =>
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
};

printInColor("This is blue text", ConsoleColor.Blue);
printInColor("This is green text", ConsoleColor.Green);

#endregion


#region Predicate
printInColor("\n================== Predicate ==================\n", ConsoleColor.DarkYellow);
Predicate<Person> isActive = person => person.IsActive;
Person bob2 = new();
Console.WriteLine(isActive(bob2));
#endregion


#region Delegates with hof and LINQ

printInColor("\n================== Func & Action with hof and LINQ ==================\n", ConsoleColor.DarkMagenta);

string foundBob = names.Find(n => n == "Bob");

Predicate<string> isJill = n => n == "Jill";
string foundJill = names.Find(isJill);

Func<string, bool> isJillFunc = n => n == "Jill";
string foundJillFirst = names.FirstOrDefault(isJillFunc);


Func<string, bool> nameStartsWithJ = n => n.StartsWith('J');

// Same thing, different syntax !!!
List<string> namesWithJ = names.Where(nameStartsWithJ).ToList(); // best option
List<string> namesWithJ2 = names.Where(n => nameStartsWithJ(n)).ToList();
List<string> namesWithJ3 = names.Where(n => n.StartsWith('J')).ToList();
List<string> namesWithJ4 = names.Where(n =>
{
    if (n.StartsWith('J'))
    {
        return true;
    }
    return false;
}).ToList();


namesWithJ.ForEach(n => Console.WriteLine(n));
namesWithJ.ForEach(Console.WriteLine); // same thing as above, simpler syntax

#endregion


Console.ReadLine();