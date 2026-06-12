//synchronous

void PrintMessagesSynchrononous()
{
	Console.WriteLine("Hello");
	Console.WriteLine("First message"); //call ti api/db 
	Thread.Sleep(3000); //wait for response (wait 3s) - we simulate a call to api by making the current thread wait ("sleep") for 3 seconds
	Console.WriteLine("Validation"); //validation
	Console.WriteLine("Third message"); //using the response
	Console.WriteLine("Bye");
}

//PrintMessagesSynchrononous();

void PrintMessagesInDifferentThreads()
{
	Console.WriteLine("Hello"); //this will be executed on the main thread - this is the only line that we know will execute first
	//Thread.Sleep(1000); //Here the current thread is the main thread

	//we don't know the order in which the next lines of code will be executed
	Thread firstThread = new Thread(() =>
	{
		//here with Thread we access the current thread which is now our firstThread
		Thread.Sleep(2000); //2s
		Console.WriteLine("First thread");
	});

	firstThread.Start(); //we need to sart the thread

	Thread secondThread = new Thread(() =>
	{
		//here with Thread we access the current thread which is our secondThread
		Thread.Sleep(1000); //1s
		Console.WriteLine("Second thread");
	});

	secondThread.Start();
}

PrintMessagesInDifferentThreads();