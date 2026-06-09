using Helpers;
using System.Diagnostics;

ConsoleHelper.PrintInColor("\n================= ASYNC / AWAIT =================\n", ConsoleColor.DarkCyan);
// async/await is a language feature that allows you to write asynchronous code in a more readable and maintainable way
// It is built on top of Tasks and the Task-based Asynchronous Pattern
// async/await allows you to write code that looks synchronous but is actually asynchronous under the hood
// It helps to avoid blocking the main thread while waiting for long-running operations to complete, improving responsiveness and scalability

ConsoleHelper.PrintInColor($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.DarkGray);

// ===> Synchronous method 
void SendMessage(string message)
{
    Console.WriteLine("Sending message ...");
    Thread.Sleep(3000);
    ConsoleHelper.PrintInColor($"Message {message} sent!", ConsoleColor.Green);
    ConsoleHelper.PrintInColor($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.Gray);
}

// ===> Asynchronous method 
// Async method => method that can be executed without blocking the thread
// Async method must return Task (if void), Task<T> (if returning a value)
// By convention, async methods should have "Async" suffix in their name
async Task SendMessageAsync(string message)
{
    // Thread ID BEFORE the await — this is the thread we started on
    ConsoleHelper.PrintInColor($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.Yellow);
    Console.WriteLine("Sending message ...");
    await Task.Delay(3000); // FREES the thread back to the pool during the wait
    // Thread ID AFTER the await — may be DIFFERENT! The continuation can resume on another thread
    ConsoleHelper.PrintInColor($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}\n", ConsoleColor.Yellow);
    ConsoleHelper.PrintInColor($"Message {message} sent!", ConsoleColor.Cyan);
}

// Thread.Sleep — BLOCKS the thread (sits idle, wasted)
// Task.Delay — FREES the thread while waiting (correct inside async)

void ShowAd()
{
    Console.WriteLine("While you wait, here's and add. Buy the new 'IPhone 17' for special price.");
}

Stopwatch stopwatch = new Stopwatch();


ConsoleHelper.PrintInColor("===== Synchronous Execution =====", ConsoleColor.DarkCyan);

stopwatch.Restart();
SendMessage("Hello Avenga Academy!");
ShowAd();
stopwatch.Stop();
ConsoleHelper.PrintInColor($"Total time {stopwatch.ElapsedMilliseconds} ms", ConsoleColor.Cyan);


ConsoleHelper.PrintInColor("===== Async WITHOUT await — Fire and Forget =====", ConsoleColor.DarkCyan);
// Notice: the method is called, but we don't wait for it to complete (no await) — it runs in the background
// This is called "Fire and Forget" — we fire the async method and forget about it, we don't care when it finishes
// This can be useful in some scenarios (e.g., logging, notifications), but in most cases, you want to await the async method to ensure it completes successfully and to handle any exceptions that may occur
stopwatch.Restart();
SendMessageAsync("Hello Avenga Academy!");
ShowAd();
// ShowAd runs right away, and the stopwatch shows almost 0ms (we didn't wait!)
stopwatch.Stop();
ConsoleHelper.PrintInColor($"Total time {stopwatch.ElapsedMilliseconds} ms", ConsoleColor.Cyan);

Console.ReadLine();


ConsoleHelper.PrintInColor("===== Async WITH await =====", ConsoleColor.DarkCyan);
// await PAUSES this code until the task finishes — but FREES the thread during the wait
// ShowAd runs only AFTER the message is sent (correct ordering)
// Total time ~ 3000ms, same as sync — BUT the thread wasn't blocked, just released
stopwatch.Restart();
await SendMessageAsync("Hello Avenga Academy!");
ShowAd();
stopwatch.Stop();
ConsoleHelper.PrintInColor($"Total time {stopwatch.ElapsedMilliseconds} ms", ConsoleColor.Cyan);

Console.ReadLine();


ConsoleHelper.PrintInColor("===== Async method with return =====", ConsoleColor.DarkCyan);

// ===> Async method that returns a value — Task<int> is a PROMISE of an int
async Task<int> GetProductPriceAsync()
{
    return 5000;
}

// This starts the task but does NOT unwrap the value — productPriceTask is a Task<int>, not an int
Task<int> productPriceTask = GetProductPriceAsync();

// await unwraps the Task<int> and gives us the actual int — no .Result, no blocking
//int productPrice = productPriceTask.Result; // This blocks the thread until the task finishes — not recommended in async code
int productPrice = await productPriceTask;
// or call the method directly with await
int productPriceValue = await GetProductPriceAsync();

Console.WriteLine("The product price is " + productPrice);


Console.ReadLine();