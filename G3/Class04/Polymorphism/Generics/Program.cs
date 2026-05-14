
using Generics.Domain;

List<string> strings = new List<string>() { "Hello", "G3" };
List<int> ints = new List<int> { 1, 2, 3 };
List<bool> bools = new List<bool> { true, false };

NonGenericHelper.PrintListOfStrings(strings);
NonGenericHelper.PrintListOfInts(ints);
NonGenericHelper.PrintListOfBools(bools);

//here we pass on the type that will be placed in the placeholder T in genericHelper
GenericHelper<string>.PrintList(strings);
GenericHelper<int>.PrintList(ints);