namespace AbstractClassesAndInterfaces.Domain.Model
{
	//we don't need to write that this class impl the IDeveloper interface, because it alredy inherits from Developer class
	//and the Developer class already implements IDeveloper interface
	public class JuniorDeveloper : Developer
	{
		public bool IsGraduated { get; set; }
		public JuniorDeveloper() { }

		public JuniorDeveloper(string firstname, string lastname, int age, string address, string phoneNumber, string projectname,
			int yearsOfExperience, List<string> programmingLanguages, bool isGraduated) : base(firstname, lastname, age, address, phoneNumber, projectname, yearsOfExperience, programmingLanguages)
		{
			IsGraduated = isGraduated;
		}
	}
}
