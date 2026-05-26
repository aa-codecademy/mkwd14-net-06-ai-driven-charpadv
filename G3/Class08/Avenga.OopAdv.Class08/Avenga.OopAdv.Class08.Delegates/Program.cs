#region Methods
using System.Runtime.CompilerServices;

void SayHello(string person)
{
    Console.WriteLine($"Hello {person}");
}
void SayHello2(string person, string person2)
{
    Console.WriteLine($"Hello {person} and {person2}");
}
void SayBye(string person)
{
    Console.WriteLine($"Bye {person}");
}
void SayWhatever(string whatever, SayDelegate sayDelegate)
{
    Console.WriteLine("Chatbot say:");
    sayDelegate(whatever);
}

void NumberMaster(int num1, int num2, NumbersDelegate numbersDelegate)
{
    Console.WriteLine($"The result is: {numbersDelegate(num1, num2)}");
}
#endregion
SayDelegate del = new SayDelegate(SayHello);
SayDelegate bye = new SayDelegate(SayBye);
SayDelegate2 del2 = new SayDelegate2(SayHello2);
SayDelegate wow = new SayDelegate(x => Console.WriteLine($"Wow {x}!"));

//Using the delegate
del("Bob");
del2("Jill", "Greg");
bye("John");
wow("Greg");


//========================================= 
SayWhatever("Test test", SayHello);
SayWhatever("Jill", SayBye);
//SayWhatever("Jill", SayHello2);
SayWhatever("Greg", x=> Console.WriteLine($"Wow {x}!"));
SayWhatever("Anne", x =>
{
    Console.WriteLine("Test test");
    Console.WriteLine($"Other test {x}");
});

//===========================================
NumberMaster(2, 5, (x, y) => x * y);
NumberMaster(10, 15, (x, y)=> x-y);
NumberMaster(10, 15, (x, y) =>
{
    if (x > y) return x; 
    return y;
});

//Declaring delegates
delegate void SayDelegate(string something);
delegate void SayDelegate2(string something, string something1);
delegate int NumbersDelegate(int num1, int num2);

