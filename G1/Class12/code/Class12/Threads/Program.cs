using Helpers;

ConsoleHelper.PrintInColor("\n================= THREADS =================\n\n", ConsoleColor.DarkCyan);
// Thread is a path of execution within a process
// They are the smallest unit of execution that can be scheduled by an operating system
// They allow a program to perform multiple tasks concurrently (at same time)

ConsoleHelper.PrintInColor($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.DarkGray);

// ===> Synchronous
// The code is executed line by line, one after another, and the next line of code will not be executed until the previous one is finished
void SendMessages()
{
    Console.WriteLine("Getting Ready...");
    Thread.Sleep(2000);

    Console.WriteLine("First message arrived!");
    Thread.Sleep(2000);

    ConsoleHelper.PrintInColor($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.DarkGray);

    Console.WriteLine("Second message arrived!");
    Thread.Sleep(2000);

    Console.WriteLine("Third message arrived!");
    Console.WriteLine("All messages are received!");
}

// ===> Asynchronous
// The code is executed concurrently, and the next line of code can be executed before the previous one is finished
void SendMessagesWithThreads()
{
    Console.WriteLine("Getting Ready...");
    Random rnd = new Random();

    Thread t1 = new Thread(() =>
    {
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);
        ConsoleHelper.PrintInColor($"First message arrived after {delay} ms! [ThreadID: {Thread.CurrentThread.ManagedThreadId}]", ConsoleColor.Green);
    });

    Thread t2 = new Thread(() =>
    {
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);
        ConsoleHelper.PrintInColor($"Second message arrived after {delay} ms! [ThreadID: {Thread.CurrentThread.ManagedThreadId}]", ConsoleColor.Yellow);
    });

    Thread t3 = new Thread(() =>
    {
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);
        ConsoleHelper.PrintInColor($"Third message arrived after {delay} ms! [ThreadID: {Thread.CurrentThread.Name}]", ConsoleColor.Magenta);
    })
    { Name = "Our Thread 3" };

    t1.Start(); t2.Start(); t3.Start();

    ConsoleHelper.PrintInColor($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.DarkGray);
    Console.WriteLine("All messages are received! (or not yet..)");
}


// ===> Synchronous execution
//SendMessages();

// ===> Asynchronous execution
SendMessagesWithThreads();


Console.ReadLine();