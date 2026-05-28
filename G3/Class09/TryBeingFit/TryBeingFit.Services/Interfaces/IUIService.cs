using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryBeingFit.Domain.Enums;
using TryBeingFit.Domain.Models;

namespace TryBeingFit.Services.Interfaces
{
    public interface IUIService
    {
        List<string> MenuItems { get; set; }
        int ChooseMenuItem(List<string> menuItems);
        int LogInMenu();
        int RoleMenu();
        StandardUser FillNewUserData();
        int MainMenu(UserRoleEnum userRole);
        int TrainMenu();
        void UpgradeToPremiumInfo();
        public int TrainMenuItems<T>(List<T> menuItems) where T: Training;
        public int ChooseEntity<T>(List<T> enetities) where T : Training;
        public int AccountMenu();
    }
}
