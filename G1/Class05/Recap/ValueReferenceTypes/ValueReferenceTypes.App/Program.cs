using ValueReferenceTypes.App;

Console.WriteLine("Hello, World!");

int num1 = 10;
int num2 = num1; // num2 gets a copy of the value of num1
num2 = 1000; // Changing num2 does not affect num1

Console.WriteLine(num1); // 10
Console.WriteLine(num2); // 1000

//int num3 = null; // This will cause a compile-time error because int is a value type and cannot be null
int? num4 = null;
//bool isTrue = null;
bool? isTrue = null;


string strNullable = null;
string str1 = "String 1";
string str2 = str1; // str2 references the same string object as str1
str2 = "String 2"; // Changing str2 does not change str1 because strings are immutable
Console.WriteLine(str1);
Console.WriteLine(str2);


Person bob = new Person("Bob", 30);
Person john = bob;
john.Name = "John"; // Changing john's name also changes bob's name because they reference the same object
bob.Age = 50;


Console.WriteLine(bob.Age);
Console.WriteLine(john.Age);
Console.WriteLine(bob.Name);
Console.WriteLine(john.Name);