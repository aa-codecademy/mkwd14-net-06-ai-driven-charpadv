using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFit.Domain.Database;
using TryBeingFit.Domain.Models;
using TryBeingFit.Services.Helpers;
using TryBeingFit.Services.Interfaces;

namespace TryBeingFit.Services.Implementations
{
    public class UserService<T> : IUserService<T> where T : User
    {
        private IDatabase<T>  _database;
        public UserService()
        {
            _database = new Database<T>();
        }
        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            //T userDb = GetById(userId);
            T userDb = _database.GetById(userId);

            if(userDb.Password != oldPassword)
            {
                throw new Exception("Old passwords do not match");
            }
            if (!ValidationHelper.ValidatePassoword(newPassword)) 
            {
                throw new Exception("Invalid password!");
            }
            userDb.Password = newPassword;
            _database.Update(userDb);
        }

        public T GetById(int id)
        {
            return _database.GetById(id);
        }

        public T LogIn(string username, string password)
        {
            T userDb = _database.GetAll().FirstOrDefault(x=> x.Username == username && x.Password == password);
            if(userDb == null)
            {
                MessageHelper.PrintMessage($"[ERROR] User with username {username} does not exist.", ConsoleColor.Red);
                return null;
            }
            return userDb;
        }

        public T Register(T userModel)
        {
            if(!ValidationHelper.ValidateName(userModel.Firstname) || !ValidationHelper.ValidateName(userModel.Lastname) || !ValidationHelper.ValidateUsername(userModel.Username) || !ValidationHelper.ValidatePassoword(userModel.Password))
            {
                MessageHelper.PrintMessage($"[ERROR] User data is invalid", ConsoleColor.Red);
                return null;
            }
            int id = _database.Insert(userModel);
            return _database.GetById(id);
        }
    }
}
