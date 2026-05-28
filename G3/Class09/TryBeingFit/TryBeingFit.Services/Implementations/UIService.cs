using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TryBeingFit.Domain.Enums;
using TryBeingFit.Domain.Models;
using TryBeingFit.Services.Helpers;
using TryBeingFit.Services.Interfaces;

namespace TryBeingFit.Services.Implementations
{
    public class UIService : IUIService
    {
        public List<string> MenuItems { get; set; }

        public int AccountMenu()
        {
            List<string> items = new List<string>() { "Change passwod" };
            return ChooseMenuItem(items);
        }

        public int ChooseEntity<T>(List<T> enetities) where T : Training
        {
            while (true) 
            {
                for(int i = 0;  i < enetities.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {enetities[i].GetInfo()}");
                }
                string input = Console.ReadLine();
                int choice = ValidationHelper.ValidateNumber(input, enetities.Count);
                if (choice == -1)
                {
                    MessageHelper.PrintMessage($"[WAR] YOU must enter a valid option!", ConsoleColor.Yellow);
                    continue;
                }
                return choice;
            }
        }

        public int ChooseMenuItem(List<string> menuItems)
        {
            while (true) 
            {
                for (int i = 0; i < menuItems.Count; i++) 
                {
                    Console.WriteLine($"[{i+1}] {menuItems[i]}");
                }
                string input = Console.ReadLine();
                int choice = ValidationHelper.ValidateNumber(input, menuItems.Count);
                if (choice == -1)
                {
                    MessageHelper.PrintMessage($"[WAR] YOU must enter a valid option!", ConsoleColor.Yellow);
                    continue;
                }
                return choice;
            }
        }

        public StandardUser FillNewUserData()
        {
            StandardUser standardUser = new StandardUser();
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName))
            {
                throw new Exception("You must enter first name!");
            }
            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                throw new Exception("You must enter last name!");
            }
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("You must enter username!");
            }
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("You must enter password!");
            }

            standardUser.Firstname = firstName;
            standardUser.Lastname = lastName;
            standardUser.Password = password;
            standardUser.Username = username;

            return standardUser;

        }

        public int LogInMenu()
        {
            List<string> menuItems = new List<string>() { "LogIn", "Register" };
            Console.WriteLine("Choose option:");
            return ChooseMenuItem(menuItems);
        }

        public int MainMenu(UserRoleEnum userRole)
        {
            MenuItems = new List<string>();
            MenuItems.Add("Account");
            MenuItems.Add("Log Out");

            switch (userRole)
            {
                case UserRoleEnum.Standard:
                    MenuItems.Add("Train");
                    MenuItems.Add("Upgrade to premium");
                    break;
                case UserRoleEnum.Premium:
                    MenuItems.Add("Train");
                    break;
                case UserRoleEnum.Trainer:
                    MenuItems.Add("Reschedule training");
                    break;
            }
            return ChooseMenuItem(MenuItems);
        }

        public int RoleMenu()
        {
            List<string> menuItems = Enum.GetNames(typeof(UserRoleEnum)).ToList();
            Console.WriteLine("Choose role:");
            return ChooseMenuItem(menuItems);
        }

        public int TrainMenu()
        {
            List<string> trainMenuItems = new List<string> { "Video", "Live" };
            return ChooseMenuItem(trainMenuItems);
        }

        public int TrainMenuItems<T>(List<T> menuItems) where T : Training
        {
            Console.WriteLine("Choose a training:");
            return ChooseEntity(menuItems);
        }

        public void UpgradeToPremiumInfo()
        {
            Console.WriteLine("Upgrade to premium offers:");
            Console.WriteLine("Live trainings");
        }
    }
}
