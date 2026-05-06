# C# Basic Recap 🙌

This recap covers the core concepts from the **C# Basics** course, following the order of the classes. Use it as a quick reference before moving on to the **C# Advanced** subject.

---

## Table of Contents

1. [💻 C# as a programming language](#-c-as-a-programming-language)
2. [🛠️ .NET overview](#️-net-overview)
3. [🖥️ Visual Studio](#️-visual-studio)
4. [📟 Console Application](#-console-application)
5. [📚 Class Library](#-class-library)
6. [🔢 Variables, Data Types and Operators](#-variables-data-types-and-operators)
7. [⌨️ Console Input and Data Conversion](#️-console-input-and-data-conversion)
8. [🔀 Conditionals](#-conditionals)
9. [🔁 Loops](#-loops)
10. [📦 Arrays](#-arrays)
11. [⚙️ Methods](#️-methods)
12. [🔤 Strings](#-strings)
13. [📅 DateTime](#-datetime)
14. [🏛️ Classes, Constructors and Access Modifiers](#️-classes-constructors-and-access-modifiers)
15. [🏷️ Enums](#️-enums)
16. [🗂️ Collections](#️-collections)
17. [🔍 LINQ](#-linq)
18. [⚠️ Error Handling and Exceptions](#️-error-handling-and-exceptions)

---

## 💻 C# as a programming language

C# is one of many programming languages with which we can build back-end web applications. This means that with this language we will build an application that will run and be stationed on a server machine. The language was built by Microsoft in 2002 and can be used for all kinds of applications, from desktop to mobile and web.

For this language to be running it has to be **compiled**. Compiling is the process of turning a source code written in one language into another language that can run that code (assembly code for some languages or some intermediate language for languages such as C#). C# is also a **strongly typed** language, meaning every variable, parameter, and return value has a specific data type that is known at compile-time and cannot be changed.

---

## 🛠️ .NET overview

.NET is a framework that provides many features for building applications with Microsoft languages such as C#. It is the platform that provides building and compiling C# code. It also acts as a management tool for all libraries that are built for C# so that they can be included and used easily. This framework also holds some important features such as managing memory or monitoring performance.

There have been multiple major versions of the .NET framework over the years:

* **.NET Framework** - The first version of .NET that works only on Windows machines (legacy)
* **.NET Core** - Cross-platform version that works on Windows, Linux, and macOS
* **.NET 5+** - The unified version that succeeded .NET Core. The "Core" was dropped from the name to represent a single future version of the framework
* **.NET 8** - The current LTS (Long Term Support) version we use in this course

### Difference between C# and .NET

A common point of confusion: **C#** is the *programming language* (syntax, keywords, rules), while **.NET** is the *platform* it runs on (the runtime, the standard libraries, the compiler, the tools). You write C# code, but .NET is what makes it actually execute.

---

## 🖥️ Visual Studio

Visual Studio is Microsoft's main tool for building applications using their languages and frameworks. This IDE provides all the things a developer can need and more. It is one of the best tools for building applications with C#. It has templates for different projects, which are already built start-up projects. It helps out by underlining code that will not work or giving suggestions on what might solve some issues. It has a full debugging tool-set which means that finding bugs and problems is much easier. It also makes building, compiling, and running code very easy and fast.


---

## 📟 Console Application

Console applications are applications that run in the console of the machine. They can be executed on the native console in Command Prompt or PowerShell if you are using Windows. This is the perfect type of application to start with learning C# because it isolates the language in a very simple environment and the focus is always on the language.

Before .NET 6, every console app required a fair amount of boilerplate:

```csharp
// Pre-.NET 6 console app
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your code goes here
        }
    }
}
```

Starting from .NET 6 (and continuing in .NET 8), the Console App template uses **top-level statements**, which removes most of the boilerplate. The compiler still generates the `Main` method behind the scenes, it's just hidden from us:

```csharp
// .NET 6+ / .NET 8 console app
Console.WriteLine("Hello, World!");
```

### Console output

```csharp
Console.Write("Hello ");          // Prints without a new line
Console.WriteLine("world!");      // Prints and adds a new line
Console.WriteLine($"2 + 2 = {2 + 2}"); // Interpolated string
```

---

## 📚 Class Library

The class library project is a special project that is made for storing and using classes. This project can't be the main running project since it is not made for running but storing classes. When we want to use classes from class libraries in other projects we need to remember to:

* Add a **reference** to that class library project to the current project
  * You can't have two projects referencing each other (no circular references)
* Add a `using` statement above in the document where you are writing your code to access the class from the class library

---

## 🔢 Variables, Data Types and Operators

A **variable** is a named piece of memory that holds a value. In C#, every variable has a fixed type that you declare upfront.

### Common data types

| Type      | Description                            | Example                  |
|-----------|----------------------------------------|--------------------------|
| `int`     | Whole number (32-bit)                  | `int age = 25;`          |
| `long`    | Larger whole number (64-bit)           | `long views = 9000000L;` |
| `double`  | Decimal number (precise)               | `double pi = 3.14;`      |
| `decimal` | High-precision decimal (money)         | `decimal price = 9.99m;` |
| `float`   | Decimal number (less precise)          | `float temp = 21.5f;`    |
| `bool`    | True or false                          | `bool isActive = true;`  |
| `char`    | A single character                     | `char letter = 'A';`     |
| `string`  | Text (sequence of characters)          | `string name = "Bob";`   |

### Declaring variables

```csharp
int age = 30;                  // Explicit type
string name = "Alice";         // Explicit type
var count = 10;                // Inferred type (the compiler figures out it's an int)
const double PI = 3.14159;     // Constant - cannot be changed after declaration
```

### Operators

```csharp
// Arithmetic
int sum = 5 + 3;        // 8
int diff = 10 - 4;      // 6
int prod = 6 * 7;       // 42
int div = 20 / 4;       // 5
int mod = 10 % 3;       // 1 (remainder)

// Comparison (always returns a bool)
bool isEqual = (5 == 5);    // true
bool notEqual = (5 != 6);   // true
bool greater = (10 > 5);    // true

// Logical
bool both = (true && false);  // false (AND)
bool either = (true || false); // true (OR)
bool negated = !true;         // false (NOT)

// Assignment shortcuts
int x = 10;
x += 5;  // x = x + 5  → 15
x -= 2;  // x = x - 2  → 13
x++;     // x = x + 1  → 14
```

---

## ⌨️ Console Input and Data Conversion

To read input from the user we use `Console.ReadLine()`, which **always returns a string**. If we need to work with that input as a number, we have to convert it.

```csharp
Console.Write("Enter your name: ");
string name = Console.ReadLine();

Console.Write("Enter your age: ");
string ageInput = Console.ReadLine();
```

### Conversion options

```csharp
// 1. Parse - throws an exception if the string is not a valid number
int age = int.Parse(ageInput);

// 2. TryParse - safer, returns true/false and outputs the result
bool success = int.TryParse(ageInput, out int parsedAge);
if (success)
{
    Console.WriteLine($"You are {parsedAge} years old.");
}
else
{
    Console.WriteLine("That was not a valid number.");
}

// 3. Convert - works with many source types, returns 0 for null
int converted = Convert.ToInt32(ageInput);
```

> **Rule of thumb:** Use `TryParse` when reading user input - it doesn't crash your program if the user types something invalid.

---

## 🔀 Conditionals

Conditionals are used to make decisions in code based on whether something is true or false.

### if / else if / else

```csharp
int score = 75;

if (score >= 90)
{
    Console.WriteLine("A");
}
else if (score >= 80)
{
    Console.WriteLine("B");
}
else if (score >= 70)
{
    Console.WriteLine("C");
}
else
{
    Console.WriteLine("F");
}
```

### switch

When checking a single value against many specific options, `switch` is cleaner than chained `if/else`.

```csharp
string day = "Monday";

switch (day)
{
    case "Monday":
    case "Tuesday":
    case "Wednesday":
    case "Thursday":
    case "Friday":
        Console.WriteLine("Workday");
        break;
    case "Saturday":
    case "Sunday":
        Console.WriteLine("Weekend");
        break;
    default:
        Console.WriteLine("Unknown day");
        break;
}
```

### Ternary operator

A short version of `if/else` for assigning values:

```csharp
int age = 20;
string status = (age >= 18) ? "Adult" : "Minor";
```

---

## 🔁 Loops

Loops let us repeat a block of code multiple times.

### for loop

Used when we know how many times we want to loop.

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteration {i}");
}
```

### while loop

Used when we want to loop until a condition becomes false. The condition is checked **before** each iteration.

```csharp
int counter = 0;
while (counter < 5)
{
    Console.WriteLine(counter);
    counter++;
}
```

### do-while loop

Same as `while`, but the condition is checked **after** each iteration, so the body always runs at least once.

```csharp
int number;
do
{
    Console.Write("Enter a positive number: ");
    number = int.Parse(Console.ReadLine());
} while (number <= 0);
```

### break and continue

* `break` - Exits the loop immediately
* `continue` - Skips the rest of the current iteration and jumps to the next one

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 5) break;       // Stops the loop completely when i is 5
    if (i % 2 == 0) continue; // Skips even numbers
    Console.WriteLine(i);     // Prints only 1 and 3
}
```

---

## 📦 Arrays

An **array** is a fixed-size, strongly-typed collection of values of the same type. Once created, the size cannot change.

```csharp
// Declare and initialize
int[] numbers = new int[5];           // Array of 5 ints, all zero by default
int[] primes = { 2, 3, 5, 7, 11 };    // Array literal
string[] names = new string[] { "Bob", "Alice", "Eve" };

// Access by index (zero-based)
Console.WriteLine(primes[0]);  // 2
primes[1] = 13;                // Modify the value at index 1

// Length
Console.WriteLine(primes.Length);  // 5
```

### Looping through an array

```csharp
// Classic for loop - gives us the index
for (int i = 0; i < primes.Length; i++)
{
    Console.WriteLine($"Index {i}: {primes[i]}");
}

// foreach - cleaner when we don't need the index
foreach (int prime in primes)
{
    Console.WriteLine(prime);
}
```

---

## ⚙️ Methods

Methods in C# are basic functions. They are called methods because everything we do in C# is contained in some classes. The benefits of functions and methods are universal, so as in other languages, in C# methods are very useful for organizing the code, reusing, and decoupling code.

The difference in strictly typed languages is that methods require a bit more oversight before writing them. When writing a C# method, there needs to be a **data type of the return value**, a **name**, and a **data type of each parameter**. If we don't want to return anything we use `void`.

```csharp
// Returns a string
public static string SayHello(string name)
{
    string result = $"Hello there {name}!";
    return result;
}

// Returns nothing (void)
public static void SayBye()
{
    Console.WriteLine("Byeeeee!");
}

// Method with multiple parameters and a return value
public static int Sum(int a, int b)
{
    return a + b;
}
```

## 🔤 Strings

Working with strings in C# can be done in different shapes and forms. There is only one way to write a string and that is with double quotes `" "`, but there are multiple ways they can be formatted.

### String building

```csharp
string name = "Alice";

string hello1 = "Hello " + name;                // Concatenation
string hello2 = string.Format("Hello {0}", name); // Format placeholders
string hello3 = $"Hello {name}";                // String interpolation (preferred)
```

### String formatting

```csharp
// Currency formatting
string currency = string.Format("{0:C}", 125.45);          // $125.45

// Percent formatting
string percent = string.Format("{0:P}", 0.5);              // 50.00%

// Custom number formatting
string customFormat = string.Format("{0:000-000-0000}", 1234567890); // 123-456-7890

// Alignment formatting
string customAlignment = string.Format("| {0,10} | {1,10} |", "Id", "Order");

// Same with interpolation
decimal price = 99.5m;
string label = $"Price: {price:C}";  // Price: $99.50
```

### Common string methods

```csharp
string ourString = "   We are learning C# and it is FUN and EASY. Okay, maybe just FUN.    ";

// Case conversion
string lower = ourString.ToLower();
string upper = ourString.ToUpper();

// Length
int length = ourString.Length;

// Split into an array of strings (by a character or substring)
string[] parts = ourString.Split('.');

// Check if it starts/ends with something
bool startsWith = ourString.StartsWith("   W");
bool endsWith = ourString.EndsWith("FUN.    ");

// Find the index of a substring (returns -1 if not found)
int indexOfFun = ourString.IndexOf("FUN");
int notFound = ourString.IndexOf("Nope");  // -1

// Check if it contains a substring
bool hasFun = ourString.Contains("FUN");

// Substring - starts at index 5, takes the next 16 characters
string sub = ourString.Substring(5, 16);

// Trim whitespace from both ends
string trimmed = ourString.Trim();

// Replace
string replaced = ourString.Replace("FUN", "AWESOME");

// Convert to/from char array
char[] chars = ourString.ToCharArray();
string back = new string(chars);
string joined = string.Join("", chars);
```

> **Important:** Strings in C# are **immutable**. Methods like `Trim`, `Replace`, and `ToUpper` do not modify the original string - they return a new one. Always assign the result.

---

## 📅 DateTime

`DateTime` is a complex type in C# representing a specific date and time. It can be created, manipulated, and formatted easily.

### Creating DateTime values

```csharp
DateTime empty = new DateTime();                   // 01/01/0001 00:00:00
DateTime custom = new DateTime(1992, 10, 15);      // A specific date
DateTime today = DateTime.Today;                   // Today's date with time 00:00:00
DateTime now = DateTime.Now;                       // Current date and time
DateTime utcNow = DateTime.UtcNow;                 // Current UTC date and time
```

### Formatting and parsing

```csharp
string formatted1 = DateTime.Now.ToString("MM/dd/yyyy");
string formatted2 = DateTime.Now.ToString("dddd, dd MMMM yyyy");
string formatted3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

// Convert string to DateTime
string dateText = "12-15-2012";
DateTime parsed = DateTime.Parse(dateText);

// Safer parsing
if (DateTime.TryParse(dateText, out DateTime safeParsed))
{
    Console.WriteLine(safeParsed);
}
```

### Manipulating DateTime

```csharp
DateTime now = DateTime.Now;

DateTime in2Days = now.AddDays(2);
DateTime fiveDaysAgo = now.AddDays(-5);
DateTime in2Months = now.AddMonths(2);
DateTime in2Years = now.AddYears(2);
DateTime in3Hours = now.AddHours(3);

int day = now.Day;
int month = now.Month;
int year = now.Year;
DayOfWeek weekday = now.DayOfWeek;

// Difference between two dates → TimeSpan
TimeSpan diff = in2Days - now;
Console.WriteLine(diff.TotalHours);  // 48
```

> Like strings, `DateTime` values are **immutable**. `AddDays`, `AddMonths`, etc., return a new `DateTime` rather than modifying the existing one.

---

## 🏛️ Classes, Constructors and Access Modifiers

### Classes

Classes are the backbone of every object-oriented language. Classes are independent and inside them, they hold methods and properties that are unique to them. When an application starts all of these classes work together to create a whole application.

A class is just a **template** - you can't print a class or use it directly. From this template we create **objects** (also called instances). If a class has a property `Name`, every object created from that class will have its own `Name`.

```csharp
public class Person
{
    // Properties (auto-implemented)
    public string Name { get; set; }
    public int Age { get; set; }

    // Method
    public void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
    }
}

// Creating and using an object
Person alice = new Person();
alice.Name = "Alice";
alice.Age = 30;
alice.Introduce();
```

### Properties

Properties are how we expose data on a class. The shorthand `{ get; set; }` syntax tells the compiler to generate the underlying field automatically.

```csharp
public class Product
{
    public string Name { get; set; }            // Read & write
    public decimal Price { get; private set; }  // Read publicly, write only inside the class
    public int Stock { get; init; }             // Set only during initialization
}
```

### Constructors

A **constructor** is a special method that runs when an object is created. Constructors don't have a return type, and their name is always the same as the class name. A class can have multiple constructors with different parameters.

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    private long AccountNumber { get; set; }

    // Parameterless constructor
    public Person()
    {
        AccountNumber = 34235432452;
    }

    // Constructor with parameters
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        AccountNumber = 25325325221;
    }

    public void Talk(string text)
    {
        Console.WriteLine($"{Name} says: {text}");
    }
}
```

```csharp
Person george = new Person();                // Calls the parameterless constructor
Person bill = new Person("Bill", 25);        // Calls the constructor with parameters
bill.Talk("Hello!");
```

### Access Modifiers

Access modifiers control **who can see and use** your property, method, or class. If we don't add an access modifier, most members default to `private`.

| Modifier             | Where it can be accessed                                       |
|----------------------|----------------------------------------------------------------|
| `public`             | Anywhere a reference to the class exists                       |
| `private`            | Only inside the class itself                                   |
| `protected`          | Inside the class and any classes derived from it               |
| `internal`           | Anywhere within the same project (assembly)                    |
| `protected internal` | Inside the same project OR in derived classes from any project |

### Static members

A `static` member belongs to the class itself, not to any specific object. You don't need to create an instance to use it.

```csharp
public class MathHelper
{
    public static double PI = 3.14159;

    public static int Square(int x) => x * x;
}

// No "new" needed - call directly on the class
double pi = MathHelper.PI;
int result = MathHelper.Square(5);
```

`Console.WriteLine`, `int.Parse`, and `DateTime.Now` are all examples of static members you've already used.

---

## 🏷️ Enums

**Enumerations** are a collection of named values that are fixed at compile time. They cannot be changed while the application is running. Enums are usually used for things that don't change, like days of the week, months, statuses, or roles.

```csharp
public enum Day
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

// Usage
Day today = Day.Wednesday;

if (today == Day.Saturday || today == Day.Sunday)
{
    Console.WriteLine("Weekend!");
}
```

By default, enum values are backed by integers starting from `0`. You can give them custom values:

```csharp
public enum HttpStatus
{
    OK = 200,
    NotFound = 404,
    InternalServerError = 500
}
```

---

## 🗂️ Collections

Using collections is not always a "one fits all" scenario. C# offers several types to fit different needs. Most of them are **generic collections**, meaning we provide the type using angle brackets `< >`.

| Collection                | Description                                                              |
|---------------------------|--------------------------------------------------------------------------|
| `List<T>`                 | Flexible, indexed, can grow as needed                                    |
| `Dictionary<TKey, TValue>`| Key-value pairs, fast lookup by key                                      |
| `Queue<T>`                | First-In-First-Out (FIFO) order                                          |
| `Stack<T>`                | Last-In-First-Out (LIFO) order                                           |
| `HashSet<T>`              | Unordered collection of unique values                                    |

### List

```csharp
List<string> names = new List<string>();
names.Add("Bob");
names.Add("Midge");
names.Add("Red");

names.Remove("Red");                            // Remove by value
names.RemoveAt(0);                              // Remove by index
bool hasMidge = names.Contains("Midge");        // true
int count = names.Count;                        // Number of items
string first = names[0];                        // Index access

// Initialize with values
List<int> numbers = new List<int>() { 2, 89, 4, 8, 6 };

// Loop
foreach (string name in names)
{
    Console.WriteLine(name);
}
```

### Dictionary

```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();
ages.Add("Alice", 30);
ages.Add("Bob", 25);
ages["Charlie"] = 40;            // Add or update via indexer

int aliceAge = ages["Alice"];    // Lookup by key
bool hasBob = ages.ContainsKey("Bob");

// Safe lookup
if (ages.TryGetValue("Dave", out int daveAge))
{
    Console.WriteLine(daveAge);
}

// Loop
foreach (KeyValuePair<string, int> pair in ages)
{
    Console.WriteLine($"{pair.Key} is {pair.Value} years old");
}
```

### Queue (FIFO)

```csharp
Queue<string> tasks = new Queue<string>();
tasks.Enqueue("Wash dishes");    // Add to the back
tasks.Enqueue("Walk the dog");
tasks.Enqueue("Buy groceries");

string next = tasks.Dequeue();   // Remove from the front → "Wash dishes"
string peek = tasks.Peek();      // Look at the front without removing
```

### Stack (LIFO)

```csharp
Stack<string> history = new Stack<string>();
history.Push("page1");
history.Push("page2");
history.Push("page3");

string current = history.Pop();  // Remove from the top → "page3"
string topPage = history.Peek(); // Look at the top without removing
```

---

## 🔍 LINQ

**LINQ (Language Integrated Query)** is a component of the .NET framework that helps in writing queries against collections. These queries are done by chaining methods, and they always work with `IEnumerable<T>` collections. LINQ methods themselves return `IEnumerable<T>`, so it's up to us to convert the result back to a `List`, array, or whatever we need (using `.ToList()`, `.ToArray()`, etc.).

To use LINQ, add `using System.Linq;` at the top of your file.

```csharp
List<string> names = new List<string>() { "bob", "midge", "Red", "Kitty", "Fez" };

// Where - filter
List<string> threeLetterNames = names.Where(x => x.Length == 3).ToList();
// → "bob", "Red", "Fez"

// Select - transform
List<int> lengths = names.Select(x => x.Length).ToList();
// → 3, 5, 3, 5, 3

// First / FirstOrDefault - take the first matching element
string firstLong = names.First(x => x.Length > 3);          // Throws if none found
string firstOrNull = names.FirstOrDefault(x => x.Length > 10); // Returns null instead

// Last / LastOrDefault - same, but from the end
string lastShort = names.Last(x => x.Length == 3);

// Any / All - boolean checks
bool anyLong = names.Any(x => x.Length > 4);   // true
bool allShort = names.All(x => x.Length < 10); // true

// Count
int countShort = names.Count(x => x.Length == 3);  // 3

// OrderBy / OrderByDescending
List<string> sorted = names.OrderBy(x => x.Length).ToList();
List<string> sortedDesc = names.OrderByDescending(x => x).ToList();

// Sum, Min, Max, Average (work on numeric data)
List<int> numbers = new List<int>() { 5, 12, 3, 8, 21 };
int sum = numbers.Sum();
int min = numbers.Min();
int max = numbers.Max();
double avg = numbers.Average();

// GroupBy
List<string> words = new List<string>() { "apple", "ant", "banana", "berry", "cherry" };
var grouped = words.GroupBy(w => w[0]);
foreach (var group in grouped)
{
    Console.WriteLine($"{group.Key}: {string.Join(", ", group)}");
}
// a: apple, ant
// b: banana, berry
// c: cherry
```

### Lambda expressions

Most LINQ methods take a **lambda expression** - a short inline function. The syntax `x => x.Length == 3` reads as "given an item `x`, return whether its length equals 3."

---

## ⚠️ Error Handling and Exceptions

Errors in C# come in two flavors:

* **Build-time (compile-time) errors** - Mistakes in the code itself (syntax errors, missing semicolons, wrong types). The compiler catches these before the program runs.
* **Runtime errors** - Mistakes that happen while the program is running (dividing by zero, accessing index `5` of a 3-element array, parsing `"abc"` as an integer). These cause **exceptions**.


### try / catch / finally

```csharp
try
{
    Console.Write("Enter a number: ");
    int number = int.Parse(Console.ReadLine());
    int result = 100 / number;
    Console.WriteLine($"100 / {number} = {result}");
}
catch (FormatException)
{
    Console.WriteLine("That wasn't a valid number.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("You can't divide by zero!");
}
catch (Exception ex)
{
    // Catches anything else - the most generic exception type
    Console.WriteLine($"Something went wrong: {ex.Message}");
}
finally
{
    // Runs no matter what - whether an exception was thrown or not
    Console.WriteLine("Done.");
}
```

### Throwing exceptions

```csharp
public static int Divide(int a, int b)
{
    if (b == 0)
    {
        throw new ArgumentException("Cannot divide by zero.", nameof(b));
    }
    return a / b;
}
```

### Common built-in exceptions

| Exception                       | When it's thrown                                          |
|---------------------------------|-----------------------------------------------------------|
| `NullReferenceException`        | Calling a member on a `null` object                       |
| `IndexOutOfRangeException`      | Accessing an array with an invalid index                  |
| `ArgumentNullException`         | A method received `null` for a required argument          |
| `ArgumentException`             | A method received an argument it can't work with          |
| `FormatException`               | Parsing a string in the wrong format (e.g. `int.Parse`)   |
| `DivideByZeroException`         | Integer division by zero                                  |
| `InvalidOperationException`     | Calling a method when the object is in the wrong state    |
| `FileNotFoundException`         | Trying to open a file that doesn't exist                  |

> **Best practice:** Don't catch `Exception` everywhere just to make errors disappear. Catch only the exceptions you can actually handle, and let the others bubble up so the bug isn't silently hidden.

---
