Console.WriteLine("Hello world"); //this code belongs to the initial, main thread

//this task has no return type - void
Task firstTask = new Task(() =>
{
	Thread.Sleep(1000);
	Console.WriteLine("First task");
});

firstTask.Start(); //we need to give this task a free thread from the thread pool by starting this task


//task that returns a value - int
Task<int> secondTask = new Task<int>(() =>
{
	Thread.Sleep(2000);
	Console.WriteLine("Second task returns a value");
	return 10;
});

secondTask.Start();

//create and start in the same time
Task.Run(() =>
{
	Thread.Sleep(1000);
	Console.WriteLine("Task that is created and started at the same time");
});

for (int i = 0; i < 20; i++) //in each execution the order might be different
{
	int tmp = i;
	Task.Run(() =>
	{
		Thread.Sleep(1000);
		Console.WriteLine(tmp);
	});
}

//we need this because the main thread on which the Program.cs runs finishes before the other tasks (on threads from the thread pool)
//this way we don't let the app end (the app waits for user input)
Console.ReadLine();