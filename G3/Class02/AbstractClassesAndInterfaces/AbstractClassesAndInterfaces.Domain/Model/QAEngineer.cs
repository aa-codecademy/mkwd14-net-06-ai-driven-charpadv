using AbstractClassesAndInterfaces.Domain.Interfaces;

namespace AbstractClassesAndInterfaces.Domain.Model
{
	public class QAEngineer : Person, IQAEngineer, IDeveloper
	{
        public int NumberOfProjects { get; set; }
		public List<string> TestingFrameworks { get; set; }

		public QAEngineer(string firstname, string lastname, int age, string address, string phoneNumber, int numberOfProjects, List<string> testingFrameworks)
		:base(firstname, lastname, age, address, phoneNumber)
		{
			NumberOfProjects = numberOfProjects;
			TestingFrameworks = testingFrameworks == null ? new List<string>() : testingFrameworks;
		}
		public override string GetProffestionalInfo()
		{
			string info = $"{Firstname} works on {NumberOfProjects}";
			if(TestingFrameworks.Count > 0)
			{
				info += $"{Firstname} knows the following frameworks:";
				foreach(string framework in TestingFrameworks)
				{
					info += framework + "\n"; //\n means new line
				}
			}
			return info;
		}

		public void TestingFeature(string feature, DateTime deadline)
		{
			Console.WriteLine($"Testing feature {feature}. The deadline is {deadline}");
		}

		public void Code()
		{
			Console.WriteLine($"{Firstname} is a QA engineer, but also writes code for some tests");
		}
	}
}
