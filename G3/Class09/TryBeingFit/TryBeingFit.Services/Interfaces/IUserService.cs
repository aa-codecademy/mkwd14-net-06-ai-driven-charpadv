using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFit.Domain.Models;

namespace TryBeingFit.Services.Interfaces
{
    public interface IUserService<T> where T : User
    {
        T LogIn(string username, string password);
        T Register(T userModel);
        T GetById(int id);
        void ChangePassword(int userId, string oldPassword, string newPassword);
    }
}
