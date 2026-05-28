using TryBeingFit.Domain.Enums;
using TryBeingFit.Domain.Interfaces;

namespace TryBeingFit.Domain.Models
{
	public class Trainer : User, ITrainer
	{
        public int YearsOfExperince { get; set; }

		public Trainer()
		{
			Role = UserRoleEnum.Trainer;
		}
        public override string GetInfo()
		{
			return $"{Firstname} {Lastname} - {YearsOfExperince}";
		}

		//the Trainer can have multiple LiveTrainings. We need to know which live training he/she wants to reschedule.  
		//For example if the training is set to be tomorrow, he can reschedule for Friday
		public void Reschule(LiveTraining training, int days)
		{
			//validation
			if(training == null)
			{
				throw new NullReferenceException("Training cannot be null");
			}

			//each trainer can only reschedule his own live trainings
			if(Id != training.Trainer.Id)
			{
				throw new Exception("You cannot reschedule this live training, because you are not the trainer for this class");
			}

	        training.NextSession = training.NextSession.AddDays(days);
		}
	}
}
