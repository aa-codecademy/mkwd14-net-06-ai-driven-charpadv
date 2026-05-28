using TryBeingFit.Domain.Enums;

namespace TryBeingFit.Domain.Models
{
	public class PremiumUser : User
	{
		List<VideoTraining> VideoTrainings { get; set; }
		LiveTraining LiveTraining { get; set; }

		public PremiumUser()
		{
			VideoTrainings = new List<VideoTraining>();
			Role = UserRoleEnum.Premium;
		}
		public override string GetInfo()
		{
			string liveTraining = LiveTraining == null ? "No live training" : LiveTraining.GetInfo();
			return $"{Firstname} {Lastname}, number of video trainings: {VideoTrainings.Count}, live training: {liveTraining}";
		}
	}
}
