using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TryBeingFit.Domain.Database;
using TryBeingFit.Domain.Models;
using TryBeingFit.Services.Interfaces;

namespace TryBeingFit.Services.Implementations
{
    public class TrainingService<T> : ITrainingService<T> where T : Training
    {
        private IDatabase<T> _database;
        public TrainingService()
        {
            _database = new Database<T>();
            //_database = new FileDatabase<T>();
        }
        public void AddTraining(T training)
        {
            //validations
            if (string.IsNullOrEmpty(training.Title))
            {
                throw new Exception("Title must not be empty");
            }
            _database.Insert(training);
        }

        public List<T> GetAllTrainings()
        {
            return _database.GetAll();
        }

        public T GetTraining(int id)
        {
            return _database.GetById(id);
        }
    }
}
