using TryBeingFit.Domain.Interfaces;

namespace TryBeingFit.Domain.Models
{
	public class LiveTraining : Training, ILiveTraining
	{
        public DateTime NextSession { get; set; }
		public Trainer Trainer { get; set; }
        public override string GetInfo()
		{
			return $"{Title} - {Description}, lasts: {Time}, date: {NextSession.Date}, trainer: {Trainer.GetInfo()}";
		}

		public int HoursToNextSession()
		{
			//for example now it is Tuesday 19:30 and the training will be Wednesday at 17:00 - it will return the hours until that time 
			return (NextSession - DateTime.Now).Hours;
		}
	}
}
