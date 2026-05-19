using TryBeingFit.Domain.Enums;

namespace TryBeingFit.Domain.Models
{
	public class StandardUser : User
	{
		//the standard users have a list of video trainings that they can exercise
        public List<VideoTraining> VideoTrainings { get; set; }

		public StandardUser() { 
		
			VideoTrainings = new List<VideoTraining>(); 
			Role = UserRoleEnum.Standard;
		}
        public override string GetInfo()
		{
			string result = $"{Firstname} {Lastname}";
			result += "\n Video trainings: \n"; //\n takes us to the next row (like clicking enter, line break)
			foreach( VideoTraining videoTraining in VideoTrainings)
			{
				result += $"{videoTraining.GetInfo()} \n"; //videoTraining is a derived class from BaseEntity, which means it has the GetInfo method
			}
			return result;
		}
	}
}
