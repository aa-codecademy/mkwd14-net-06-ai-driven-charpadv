using Helpers;
using MemoryAllocation;

#region Value & Reference types
ExtendedConsole.PrintInColor("\n=============== STACK & HEAP ===============\n\n", ConsoleColor.DarkCyan);

// STACK
// => part of the RAM memory used for static memory allocation
// => stores value types and reference to the reference type

// HEAP
// => part of the RAM memory used for dynamic memory allocation
// => stores the actual data of the reference types
// => is managed by the garbage collector (GC), which automatically frees up memory that is no longer being used

ExtendedConsole.PrintInColor("\n=============== Value type & Reference type ===============\n", ConsoleColor.Cyan);

// VALUE TYPES => both *reference* (variable) and *value* are stored on the STACK
// bool, byte, char, int, decimal, double, enum, float, long, short, struct...

// REFERENCE TYPES => *reference* is stored on the STACK, the actual *value* on the HEAP
// classes (objects), interface, delegate, *string*...

// *STRINGS* => special type, are considered reference type

Console.WriteLine("======= Value types =======\n");

int num1 = 10;
int num2 = num1; // it assignes only the value to the new variable num2
//int num2 = 10;
num2 = 20; // the change won't affect num1 
Console.WriteLine(num1); // 10
Console.WriteLine(num2); // 20


Console.WriteLine("\n======= Reference types =======\n");

// ===> Example: List<int>
List<int> ints1 = new List<int> { 1, 2, 3 };
List<int> ints2 = ints1; // passing reference to the ints1 list
ints2[1] = 100; // will affect the original ints1 list

ints1.ForEach(Console.WriteLine); // 1, 100, 3
ints2.ForEach(Console.WriteLine); // 1, 100, 3

// ===> Example: User
User john = new User("John", "Malkovic", 70);

User john2 = john; // passing reference to the john object
john2.Age = 32; // will affect john object as well

User john3 = john2; // passing reference to the john2 object | indirectly to john object, same memory location in the heap.. same object
john3.LastName = "Doe"; // will affect john object as well

john.PrintInfo(); // John Doe (32)
john2.PrintInfo(); // John Doe (32)
john3.PrintInfo(); // John Doe (32)


Console.WriteLine("\n======= Strings =======\n");

// ===> Example: *String*
string stringOne = "String One";
string stringTwo = stringOne;
stringTwo = "String Two";
// ***NOTE*** Even though strings are REFERENCE type and the values are stored on the heap, they behave like VALUE types in many ways

Console.WriteLine(stringOne); // String One
Console.WriteLine(stringTwo); // String Two

#endregion

#region Objects Lifecycle


#endregion


Console.ReadLine();