//the return type of an async method must be a Task
//depending on the return type of the method we could have Task (void), Task<int>... Task<T>
async Task SendMessage(string message)
{
	Console.WriteLine("Sending a message...");

	//this code in the task is sent away to be executed by another thread
	//this task could be any code that might take some thime to execute for ex. call to db/api
	//we want the code Console.WriteLine("The message was sent"); to wait for the message to be sent (for the task to finish executing)
	//that's why we mark the method as async - we release the main thread so other tasks can be executed in the meantime
	//but we mark this task with await so that the rest of the code from this method  Console.WriteLine("The message was sent"); waits for the task to be done before executing
	await Task.Run(() =>
	{
		Thread.Sleep(1000); //simpulate an operation that lasts at least 1s (some api/db call)
		Console.WriteLine("Message " + message);
	});

	Console.WriteLine("The message was sent"); //this line will wait for the task to end before executig
}

void Done()
{
	Console.WriteLine("Done");
}

//SendMessage("Hello G3");
//Done(); //done will execute while we wait for the Task to finish (in the middle of executing the Sendmessage, because the SendMessage releases the main thread and moves the task that is causing waiing time to another thread


await SendMessage("Hello G3"); //when we add await we tell teh rest of the code that they need to wait for this method to end
Done(); //Done will wait for SendMessage to end

Console.ReadLine();