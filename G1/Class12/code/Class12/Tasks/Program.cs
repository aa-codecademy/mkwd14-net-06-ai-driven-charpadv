using Helpers;

ConsoleHelper.PrintInColor("\n================= TASKS =================\n\n", ConsoleColor.DarkCyan);
// Tasks represent asynchronous operations
// Unlike the threads in C#, Tasks are not opening a new execution path every time
// They get queued to be executed asynchronously by an available thread
// This is done by a system called the ***Thread Pool*** 

ConsoleHelper.PrintInColor($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.DarkGray);

ConsoleHelper.PrintInColor("======= Task Status Lifecycle =======", ConsoleColor.Cyan);

// ===> Old pattern 
//Task myTask = new Task(() => { });
//myTask.Start();

// ===> Modern — use this
Task myTask = Task.Run(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("Running after 2000 ms");
});

Console.WriteLine($"Right after start: {myTask.Status}"); // WaitingToRun 
Thread.Sleep(500);
Console.WriteLine($"While running: {myTask.Status}"); // Running
myTask.Wait(); // actually wait for completion
Console.WriteLine($"After completion: {myTask.Status}"); // RanToCompletion


ConsoleHelper.PrintInColor("======= Task<T> - Returning a Value =======", ConsoleColor.Cyan);

// ===> Single task with return type 
Task<int> valueTask = Task.Run(() =>
{
    Thread.Sleep(1500);
    return 300;
});

// .Result blocks the calling thread until the task finishes
// Fine in console apps — dangerous in UI apps / ASP.NET (can deadlock)
Console.WriteLine(valueTask.Result);
Console.WriteLine("Status after .Result " + valueTask.Status);


ConsoleHelper.PrintInColor("======= 20 Tasks =======", ConsoleColor.Cyan);
// The loop itself is synchronous — all 20 tasks are STARTED one by one,
// but they all RUN concurrently on the thread pool
// Notice: 20 tasks don't create 20 threads — the pool REUSES threads!

Random rnd = new Random();
for (int i = 1; i <= 20; i++)
{
    int temp = i;
    Task.Run(() =>
    {
        // TIP: Try adding a debugger here (debugging asynchronous code is a bit tricky)
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);
        Console.WriteLine($"Task {temp} done after {delay} ms. [Thread ID: {Thread.CurrentThread.ManagedThreadId}]");
    });
}

ConsoleHelper.PrintInColor($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.DarkGray);
Console.WriteLine("  Main thread is FREE while tasks run...\n");


Console.ReadLine();