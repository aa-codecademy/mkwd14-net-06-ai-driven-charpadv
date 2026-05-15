using System.Runtime.ExceptionServices;

namespace ExtensionMethods.Domain
{
	public static class EmployeeHelper
	{
		public static void PrintEmployee(Employee employee)
		{
			Console.WriteLine($"{employee.Firstname} {employee.Lastname} lives on {employee.Address}");
		}

		public static void Print(this Employee employee)
		{
			Console.WriteLine($"{employee.Firstname} {employee.Lastname} lives on {employee.Address}");
		}

		public static void PrintEmployeeInfoWithAge(this Employee employee, int age)
		{
			Console.WriteLine($"{employee.Firstname} {employee.Lastname} lives on {employee.Address}");
		}

	}
}
