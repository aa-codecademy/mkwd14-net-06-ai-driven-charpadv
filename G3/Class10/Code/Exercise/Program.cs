string folderPath = @"..\..\..\Exercise";
string filePath = folderPath + @"\calculations.txt";

string Calculate(int num1, int num2)
{
	return $"{num1} + {num2} = {num1 + num2}";
}

Console.WriteLine("Enter first number");
string firstInput = Console.ReadLine(); //readLine is always string

Console.WriteLine("Enter second number");
string secondInput = Console.ReadLine();

bool firstSuccess = int.TryParse(firstInput, out int firstNumber);
bool secondSuccess = int.TryParse(secondInput, out int secondNumber);

if(firstSuccess && secondSuccess) //if the user entered valid numbers
{
	string result = Calculate(firstNumber, secondNumber);
	Console.WriteLine(result);

	//we MUST create a folder before trying to write into a file. StreamWriter will create only the missing file, but not the missing folder(s)
    Directory.CreateDirectory(folderPath);
	Console.WriteLine($"The result was successfully calculated and logged into {filePath}");
	//StreamWriter will create the file if the file does not exist
	//append = true
	using(StreamWriter sw = new StreamWriter(filePath, true))
	{
		sw.WriteLine($"{DateTime.Now: dd.MM.yyyy HH.mm.ss} : {result}");
		sw.WriteLine("==================================================");
	}
}