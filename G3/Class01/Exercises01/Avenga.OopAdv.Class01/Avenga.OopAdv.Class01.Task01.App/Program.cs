// test names
using Avenga.OopAdv.Class01.Task1.Logic.Services;


// ============================ FIRST WAY =======================================
Console.WriteLine("============================ FIRST WAY =======================================");
var listOfNames = new List<string>()
            {
                "Nulla",
                "Lorem",
                "eros",
                "dolor",
                "Vestibulum",
                "Hello"
            };

// test text 
var text = $"Lorem ipsum dolor sit amet, consectetur Hello dolor dolor  Lorem  Lorem  adipiscing elit. dolor Lorem Hello Vestibulum pharetra Lorem mattis libero, eget porttitor eros posuere eu. Quisque sit amet maximus eros. Donec id placerat massa, dignissim fermentum mi. Pellentesque habitant morbi tristique senectus  Hello et netus et malesuada fames ac turpis egestas. Vestibulum eleifend sem eu velit fermentum eleifend at sed justo. Cras fermentum elementum placerat. Morbi metus tortor, consectetur vehicula leo a, Hello lacinia eleifend quam. Vivamus quis quam Hello Hello quis justo dignissim pulvinar.Aliquam iaculis augue lorem, ac fermentum lorem gravida sit amet.Nulla consectetur lacus felis, at cursus elit mattis ut. Fusce sed congue dolor. Hello Nulla tempus  Hello laoreet velit. Hello";

var searchService = new SearchService();
var result = searchService.CountAppearancesInText(text, listOfNames);

foreach (var item in result)
{
    Console.WriteLine($"Name: {item.Key} is contained {item.Value}");
}
Console.WriteLine("-------------- SECOND WAY ----------------");
var result2 = searchService.CountAppearancesInText2(text, listOfNames);

foreach (var item in result2)
{
    Console.WriteLine($"Name: {item.Name} is contained {item.Appearance}");
}
Console.WriteLine("-------------- THIRD WAY ----------------");
searchService.CountAppearancesInText3(text, listOfNames);

Console.WriteLine("===================================================================");

// ======================== SECOND WAY ===========================================
Console.WriteLine("======================== SECOND WAY ===========================================");


List<string> names = new List<string>();

Console.WriteLine("Enter names (type 'x' to stop):");

while (true)
{
    string input = Console.ReadLine();

    if (input.ToLower() == "x")
        break;

    if (!string.IsNullOrWhiteSpace(input))
        names.Add(input);
}


Console.WriteLine("Enter text:");
string text1 = Console.ReadLine();


var result1 = searchService.CountAppearancesInText(text1, names);


Console.WriteLine("---- RESULTS ----");

foreach (var item in result1)
{
    Console.WriteLine($"Name: {item.Key} is contained {item.Value} times");
}

Console.ReadLine();
Console.WriteLine("===================================================================");
