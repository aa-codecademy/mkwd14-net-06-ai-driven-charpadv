using TryBeingFit.Domain.Models;

namespace TryBeingFit.Domain.Interfaces
{
	public interface ITrainer
	{
		void Reschule(LiveTraining training, int days);
	}
}
