using AbstractClassesAndInterfaces.Domain.Interfaces;

namespace AbstractClassesAndInterfaces.Domain.Model
{
	public class Developer : Person, IDeveloper
	{
        public string ProjectName { get; set; }
        public int YearsOfExperience { get; set; }
        public List<string> ProgrammingLanguages { get; set; }

		public Developer() { }

		public Developer(string firstname, string lastname, int age, string address, string phoneNumber, string projectname, 
			int yearsOfExperience, List<string> programmingLanguages)// when we create a developer this constructor is called
			: base(firstname, lastname, age, address, phoneNumber)// here the Developer constructor calls the Person (parent, base) constructor
		{
			ProjectName = projectname;
			YearsOfExperience = yearsOfExperience;
			//when we have collections, the default value is null - so we must create a new empty list here, because otherwise if we call programmingLanguaes.Count or .Add it will be null.Count and that will throw an error
			ProgrammingLanguages = programmingLanguages == null ? new List<string>() : programmingLanguages;
		}
		
		//this method must be present because it is an abstract method in the parent class (the base class, Person) 
		//we must have an impl here
        public override string GetProffestionalInfo()
		{
			return $"{Firstname} {Lastname} works as a developer on {ProjectName}. He has an experience of {YearsOfExperience} years.";
		}

		//we must implement the methods from the interfaces that this class implements
		public void Code()
		{
			Console.WriteLine("Coding.....");
			if(ProgrammingLanguages.Count > 0)
			{
				foreach(string language in ProgrammingLanguages)
				{
					Console.WriteLine($"Programming in {language}");
				}
			}
		}
	}
}
