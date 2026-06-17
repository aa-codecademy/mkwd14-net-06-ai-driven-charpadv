using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesAndPrinciple.GoodPractices
{
    #region CLASSES, PROPERTIES, FIELDS, METHODS, VARIABLES, NAMESPACES, PARAMETERS, ETC.
    // BAD EXAMPLES:
    internal class user
    {
        private readonly string usersFolder = @"C:\users";
        public int id;
        public string username;
        public string Password;



        public int age;
        public bool Logged { get; set; } = false;
        public List<string> HobbyList { get; set; }

        public void Username(string Username)
        {
            this.username = Username;
        }
        public void changePwd(string pwd)
        {
            Password = pwd;
        }
        public async void GetUsers()
        {
            // code
        }
    }

    internal class User
    {
        private readonly string _usersFolder = @"C:\users";

        public int Age { get; set; }
        public bool IsLoggedIn { get; set; }
        public List<string> Hobbies { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            
        }

        public void ChangeUsername(string username)
        {
            Username = username;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
        public async Task GetUsersAsync()
        {
            // code
        }

    }
    #endregion

    #region ENUMS
    // BAD EXAMPLE:
    public enum RoleEnum
    {
        Admin,
        User,
        Manager
    }

    // GOOD EXAMPLE:
    public enum Role
    {
        Admin = 1,
        User,
        Manager
    }
    //public enum Role
    //{
    //    Admin = 1,
    //    User = 2,
    //    Manager = 3
    //}
    #endregion

    #region INTERFACES
    // BAD EXAMPLE:
    public interface iuserrepository
    {
        //.... code
    }
    public interface UserService
    {
        //... code
    }

    // GOOD EXAMPLE:
    public interface IUserRepository
    {
        //.... code
    }
    public interface IUserService
    {
        //... code
    }
    #endregion
}
