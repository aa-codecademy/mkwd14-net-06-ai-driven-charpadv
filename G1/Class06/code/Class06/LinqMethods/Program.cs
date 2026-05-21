using LinqMethods.Data;
using LinqMethods.Entities;
using LinqMethods.Helpers;

Console.WriteLine("Hello, World!");


ConsoleHelper.PrintInColor("\n==================== LINQ ====================\n", ConsoleColor.DarkCyan);
// LINQ (Language Integrated Query) is a powerful feature in C# and other .NET languages that allows you to query collections of data (like arrays, lists, databases, etc.). 


ConsoleHelper.PrintInColor("\n================== Where ==================\n", ConsoleColor.Red);
// Where filters items by an expression that must be true or false
// Where always returns IEnumerable of the same type as the target collection
// Returns the number of elements that met the condition

// LINQ with lambda
IEnumerable<Student> findBobsLambda = SEDC.Students
    .Where(s => s.FirstName.Equals("Bob", StringComparison.OrdinalIgnoreCase));

// SQL-like LINQ
IEnumerable<Student> findBobsSql = from s in SEDC.Students
                                   where s.FirstName == "Bob"
                                   select s;


ConsoleHelper.PrintInColor("\n================== Select ==================\n", ConsoleColor.Yellow);
// Select creates a collection with a different form of the initial collection by an expression that can be any value
// Select returns IEnumerable with the type of the value in the expression
// Returns the same number of elements as the initial collection

List<string> firstNames = SEDC.Students.Select(s => s.FirstName).ToList();
firstNames.PrintSimple();

// Example: Get students which are part-time and have subjects from the programming academy
// SQL like syntax complex example
IEnumerable<Student> programmingStudentsSqlLike = from student in SEDC.Students
                                                  where student.IsPartTime
                                                  && (from subject in student.Subjects
                                                      where subject.Type == Academy.Programming
                                                      select subject).Count() != 0
                                                  select student;

// Lambda complex example
List<Student> programmingStudentsLambda = SEDC.Students
    .Where(s => s.IsPartTime
    && s.Subjects.Any(sub => sub.Type == Academy.Programming))
    .ToList();


ConsoleHelper.PrintInColor("\n================== First/Single/Last (OrDefault) ==================\n", ConsoleColor.Green);

// First => Gets first element, if no elements it will throw error
// FirstOrDefault => Gets first element, if no elements will return default and will not throw error
// Last => Gets last element, if no elements it will throw error
// LastOrDefault => Gets last element, if no elements will return default and will not throw error
// Single => Gets the only element from list, if more than one elements or no elements will throw error
// SingleOrDefault => Gets the only element from the list, if no elements will return default value, if more than one will throw error

Student petko = SEDC.Students.FirstOrDefault(s => s.FirstName == "Petko");

//Student bob = SEDC.Students.SingleOrDefault(s => s.FirstName == "Bob");



ConsoleHelper.PrintInColor("\n================== Select Many ==================\n", ConsoleColor.Red);
// It flatens list of lists
// Flattening => When we make one list out of multiple lists of the same type



ConsoleHelper.PrintInColor("\n================== Distinct/DistinctBy ==================\n", ConsoleColor.Yellow);
// Removes all duplicate values from a collection
// Returns IEnumerable of the same type as the original collection

List<string> distinctStudentNames = SEDC.Students
    .Select(s => s.FirstName)
    .Distinct()
    .ToList();
distinctStudentNames.PrintSimple();


ConsoleHelper.PrintInColor("\n================== Any/All ==================\n", ConsoleColor.Green);

// Any
// Checks if there is at least one item in a collection that follows an expression
// Returns true or false depending on the result
bool hasBob = SEDC.Students.Any(s => s.FirstName == "Bob");

// All
// Checks if all items of a collection follow a particular expression
// Returns true or false depending on the result
bool areAllAdults = SEDC.Students.All(s => s.Age >= 18);




ConsoleHelper.PrintInColor("\n================== Except ==================\n", ConsoleColor.Red);
// Creates a new collection that is missing some particular items
// It returns IEnumerable of the same type as the original collection






ConsoleHelper.PrintInColor("\n================== OrderBy/ThenBy (Descending) ==================\n", ConsoleColor.Yellow);
// Orders a collection by a given value
// Can order by ascending - OrderBy and descending - OrderByDescending
// Can have multiple levels of ordering with the ThenBy and ThenByDescending methods
// Returns IEnumerable of the same type as the original collection








ConsoleHelper.PrintInColor("\n================== GroupBy ==================\n", ConsoleColor.Green);
// Used to group elements of a sequence based on a key
// It returns a collection of IGrouping<TKey, TElement> objects, where each IGrouping object represents a group and contains a key and a sequence of elements that share that key.








Console.ReadLine();


/* 
    MORE USEFUL LINQ METHODS
    
    1) Max/MaxBy & Min/MinBy
    2) Count()
    3) Sum(), Average()
    4) Take(), Skip()
    5) Aggregate()
    6) TakeWhile(), SkipWhile()
    7) Intersect()
    etc...
*/