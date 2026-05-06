// 1.Create a console application that detect provided names in a provided text 🔹
// The application should ask for names to be entered until the user enteres x
// After that the application should ask for a text
// When that is done the application should show how many times that name was included in the text ignoring upper/lower case


// 1) The application should ask for names to be entered until the user enteres x
List<string> names = new();
Console.WriteLine("Enter names (type 'x' to stop):");
while (true)
{
    string input = Console.ReadLine();
    if (input.ToLower() == "x")
    {
        break;
    }
    names.Add(input);
}

// 2) After that the application should ask for a text
Console.WriteLine("Enter text: ");
string text = Console.ReadLine();

string[] words = text.Split(' ');

// 3) When that is done the application should show how many times that name was included in the text ignoring upper/lower case
Console.WriteLine("======= Result =======");
foreach (var name in names) // john , bob
{
    int count = 0;
    foreach (var word in words) // john, bob, JOHN, sara, ana, JoHn
    {
        // The second loop is used only to find the appearances of the name
        if (name.ToLower() == word.ToLower())
        {
            count++;
        }
        //if (name.Equals(word, StringComparison.OrdinalIgnoreCase))
        //{
        //    count++;
        //}
    }
    Console.WriteLine($"{name} is found {count} times.");
}


Console.ReadLine();