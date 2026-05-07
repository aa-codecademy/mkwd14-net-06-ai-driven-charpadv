using AbstractClassesAndInterfaces.Domain.Interfaces;

namespace AbstractClassesAndInterfaces.Domain.Model
{
	//we can inherit from only one class, but we can implement multiple interfaces
	public class DevOpsEngineer : Person, IDeveloper, IDevOpsEngineer
	{
		public bool IsAzureCertified { get; set; }
        public bool IsAWSCertified { get; set; }

		public DevOpsEngineer(string firstname, string lastname, int age, string address, string phoneNumber, bool isAzureCertified, bool isAWSCertified)
		:base(firstname, lastname, age, address, phoneNumber)
		{
			IsAzureCertified = isAzureCertified;
			IsAWSCertified = isAWSCertified;
		}
		public bool CheckInfrastructure(int status)
		{
			List<int> okStatuses = new List<int>() {200, 202, 204};
			return okStatuses.Contains(status);
		}

		public void Code()
		{
			if (IsAWSCertified)
			{
				Console.WriteLine("Writing code for AWS portal services");
			}

			if (IsAzureCertified)
			{
				Console.WriteLine("Writing code for Azure portal services");
			}
		}

		public override string GetProffestionalInfo()
		{
			string info = $"{Firstname}";
			if(IsAWSCertified)
			{
				info += "has AWC certificate.";
			}
			if(IsAzureCertified)
			{
				info+="has Azure certificate.";
			}

			return info;
		}
	}
}
