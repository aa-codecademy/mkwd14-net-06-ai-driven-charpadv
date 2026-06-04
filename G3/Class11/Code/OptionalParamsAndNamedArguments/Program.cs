void CalculationWithNoOptionalParams(int num1, int num2, string operation)
{
	switch (operation)
	{
		case "+":
			Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
			break;
		case "-":
			Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
			break;
		default:
			Console.WriteLine("Inavlid operator");
			break;
	}
}

CalculationWithNoOptionalParams(3, 4, "-");  //we must provide values for all params
//CalculationWithNoOptionalParams(3, 4); //ERROR

//Always put the required paramms first, then the optional params
//we must provide values for num1, num2, but we do not need to provide a value for operation
//if we do not provide a value for operation its value will be +; If we provide a value it will have the value we provided
void CalculationWithOneOptionalParam(int num1, int num2, string operation = "+")
{
	switch (operation)
	{
		case "+":
			Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
			break;
		case "-":
			Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
			break;
		default:
			Console.WriteLine("Inavlid operator");
			break;
	}
}

CalculationWithOneOptionalParam(5, 4, "-");
CalculationWithOneOptionalParam(5, 4); //the value for operation will be the default one: +

void CalculationWithAllOptionalParams(int num1 = 0, int num2 = 0, string operation = "+")
{
	switch (operation)
	{
		case "+":
			Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
			break;
		case "-":
			Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
			break;
		default:
			Console.WriteLine("Inavlid operator");
			break;
	}
}

//we can call it without params, with only one, with two or with all three
//the values will be assigned to the params in order
CalculationWithAllOptionalParams(); //0,0,+
CalculationWithAllOptionalParams(10); //10, 0, +
CalculationWithAllOptionalParams(10, 12); //10, 12, +
CalculationWithAllOptionalParams(10, 12, "-"); //10, 12, -

//Named arguments

//when using named arguments we use the name of the param to tell which value should go to which param
//when using named arguments we caqn change the order of passing the value
CalculationWithAllOptionalParams(num1: 5, num2: 10, operation: "-");
CalculationWithAllOptionalParams(num2: 7, num1: 10, operation: "+");
CalculationWithAllOptionalParams(operation: "-"); //num1=0, num2=0, operation = -
CalculationWithAllOptionalParams(num1: 5); //num1=5, num2=0, operation=+
CalculationWithAllOptionalParams(operation:"-", num2: 5); //num1=0, num2=5, operation=-


