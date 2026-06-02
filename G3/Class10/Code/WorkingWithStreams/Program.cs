string appPath = @"..\..\..\";
string myFolder = appPath + "myFolder"; // ..\..\..\myFolder
string txtPath = myFolder + @"\test.txt"; // ..\..\..\myFolder\test.txt

if (!Directory.Exists(myFolder)) //always check if the folder already exists
{
	Directory.CreateDirectory(myFolder);
}

//if the test.txt file does not exist, the Stream writer creates it for us
using(StreamWriter sw = new StreamWriter(txtPath))
{
	sw.WriteLine("Hello G3!");
	sw.WriteLine("We are writing from stream writer");
}
//sw only exists and can be used in the using block {}
//after the }  sw object is disposed (released) and the connection with the file system is closed

//here we are opening a new stream
//if there is something already in the file it will be overwritten
using(StreamWriter sw = new StreamWriter(txtPath))
{
	sw.WriteLine("Another text");
	sw.WriteLine("This is another line");
	sw.WriteLine("This is yet another line");
}

//if we want to append text instead of overwriting we need to send a true value for the append param in the StreamWriter constructor
using(StreamWriter sw = new StreamWriter(txtPath, true))
{
	sw.WriteLine("This line was appended to the previous text");
}

//reading
using(StreamReader sr = new StreamReader(txtPath))
{
	string firstLine = sr.ReadLine(); //read line reads one line from the file
	string secondLine = sr.ReadLine();
	string restOfTheText = sr.ReadToEnd();

	Console.WriteLine(firstLine);
	Console.WriteLine(secondLine);
	Console.WriteLine(restOfTheText);
}//sr only exists and can be used in the using block {}
 //after the } sr object is disposed (released) and the connection with the file system is closed