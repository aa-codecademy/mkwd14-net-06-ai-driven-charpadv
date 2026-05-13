using Generics.Helpers;

Console.WriteLine("Hello, World!");

/*
	*GENERICS* => concept of writing code that can work with multiple types while maintaining type safety.
	
	=> Generics allow you to write classes, methods, and interfaces that can work with any data type. This promotes code reusability, as the same generic type or method can be used with different data types without needing to rewrite the code.
	
	=> Example: List<T> => T is a placeholder for any type of data
	
	=> Types of generic entities:
		1) Generic methods
		2) Generic classes
		3) Generic interfaces 

	=> Usecases:
		1) Generic Repository (Data Access) classes 
		2) Generic Service classes
		3) Generic Helper methods/classes
*/

#region Generic Methods
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\n\n================ Generic Methods ================\n");
Console.ResetColor();

List<int> integers = new() { 1, 2, 3, 4, 5 };
List<string> strings = ["str1", "str2", "str3"];
List<bool> bools = new List<bool>() { true, false, true };

// ===> NON GENERIC METHODS EXAMPLE

NonGenericListHelper nonGenericListHelper = new NonGenericListHelper();

//nonGenericListHelper.PrintStrings(strings);
//nonGenericListHelper.PrintInfoForStrings(strings);

//nonGenericListHelper.PrintIntegers(integers);
//nonGenericListHelper.PrintInfoForIntegers(integers);

//nonGenericListHelper.PrintBooleans(bools);
//nonGenericListHelper.PrintInfoForBooleans(bools);

// => we need new methods for bool, product, user, long, double ..... BAD !


// ===> GENERIC METHODS EXAMPLE

GenericListHelper genericListHelper = new GenericListHelper();

GenericListHelper.PrintItemsInfo<string>(strings); // not necessery to explicitly write the type, but for learning it's helpful
genericListHelper.PrintItems<string>(strings);

// Same as above, but without explicitly writing the type, as the compiler can infer it from the argument
//GenericListHelper.PrintItemsInfo(strings);
//genericListHelper.PrintItems(strings);

GenericListHelper.PrintItemsInfo<int>(integers);
genericListHelper.PrintItems<int>(integers);

//GenericListHelper.PrintItemsInfo(integers);
//genericListHelper.PrintItems(integers);

GenericListHelper.PrintItemsInfo(bools);
genericListHelper.PrintItems(bools);

// => no need for new methods for different types !!!

#endregion


#region Generic Classes

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\n================ Generic Classes ================\n");
Console.ResetColor();



#endregion