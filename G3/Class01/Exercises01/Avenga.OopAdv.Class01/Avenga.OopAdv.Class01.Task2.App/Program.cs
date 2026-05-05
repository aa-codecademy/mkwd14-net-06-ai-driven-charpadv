using Avenga.OopAdv.Class01.Task2.Logic.Services;

var freeDayService = new FreeDayService();

while (true)
{
    Console.WriteLine("Enter a date (MM.dd.yyyy):");

    string input = Console.ReadLine();

    DateTime date;

    // validation
    if (!DateTime.TryParse(input, out date))
    {
        Console.WriteLine("Invalid date format!");
        continue;
    }

    //bool isNonWorking = freeDayService.CheckIfDateIsNonWorkingDay(date);
    //bool isNonWorking = freeDayService.CheckIfDateIsNonWorkingDay1(date);
    bool isNonWorking = freeDayService.CheckIfDateIsNonWorkingDay2(date);

    if (isNonWorking)
        Console.WriteLine("This is a NON-WORKING day ❌");
    else
        Console.WriteLine("This is a WORKING day ✅");

    Console.WriteLine("Do you want to check another date? (yes/no)");
    string answer = Console.ReadLine().ToLower();

    if (answer != "yes")
        break;

    Console.Clear();
}