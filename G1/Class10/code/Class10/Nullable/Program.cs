using Helpers;
using Nullable;

ExtendedConsole.PrintInColor("\n================== NULLABLE ==================\n\n", ConsoleColor.Cyan);

// ===> VALUE types are NOT NULLABLE by default

// int number = null; // won't work because int is not nullable by default
int? number = null; // with the '?' we can make the non-nullable types to be nullable

double decimalNumber = 465.545;
//decimalNumber = null; // won't work
double? decimalNullable = null;

// bool isTrue = null; // won't work
bool? isTrue = null;

//DateTime date = null; // won't work => struct is value type / non-nullable by default
DateTime? date = null;

// NOTE: string is nullable by default
string text = null;
string? text2 = null; // here we explicitly tell that this variable is nullable


// ===> PERSON EXAMPLE

Person bob = new Person();
bob.Score = null;

Console.ReadLine();