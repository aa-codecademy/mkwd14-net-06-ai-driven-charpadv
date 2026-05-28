using TryBeingFit.Domain.Enums;
using TryBeingFit.Domain.Models;
using TryBeingFit.Services.Implementations;
using TryBeingFit.Services.Interfaces;

ITrainingService<VideoTraining> _videoTrainingServce = new TrainingService<VideoTraining>();
ITrainingService<LiveTraining> _liveTrainingServce = new TrainingService<LiveTraining>();

IUserService<Trainer> _trainerService = new UserService<Trainer>();
IUserService<StandardUser> _standardService = new UserService<StandardUser>();
IUserService<PremiumUser> _premiumService = new UserService<PremiumUser>();


IUIService _uiservice = new UIService();
User _currentUser = null;

Seed();

int option = _uiservice.LogInMenu();
Console.Clear();
if(option == 1) // login
{
    int roleChoice = _uiservice.RoleMenu();
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
    UserRoleEnum role = (UserRoleEnum)roleChoice;
    switch (role)
    {
        case UserRoleEnum.Standard:
            _currentUser = _standardService.LogIn(username, password);
            break;
        case UserRoleEnum.Premium:
            _currentUser = _premiumService.LogIn(username, password);
            break;
        case UserRoleEnum.Trainer:
            _currentUser = _trainerService.LogIn(username, password);
            break;
    }

}
else
{
    StandardUser standardUser = _uiservice.FillNewUserData();
    _currentUser = _standardService.Register(standardUser);
}

int mainMenuOption = _uiservice.MainMenu(_currentUser.Role);
string menuItem = _uiservice.MenuItems[mainMenuOption - 1];
switch (menuItem)
{
    case "Train":
        int trainOption = 1;
        if(_currentUser.Role == UserRoleEnum.Premium)
        {
            trainOption = _uiservice.TrainMenu();
        }
        if(trainOption == 1) //video
        {
            List<VideoTraining> videoTrainings = _videoTrainingServce.GetAllTrainings();
            int trainOptions = _uiservice.TrainMenuItems(videoTrainings);
            VideoTraining videoTraining = videoTrainings[trainOptions - 1];
            Console.WriteLine("You chose:");
            Console.WriteLine($"{videoTraining.Title} - {videoTraining.Time}");
            Console.ReadLine(); 
        }
        break;
    case "Account":
        int accountChoice = _uiservice.AccountMenu();
        if (accountChoice == 1)
        {
            Console.WriteLine("Enter old password");
            string oldPassword = Console.ReadLine();
            Console.WriteLine("Enter new password");
            string newPassword = Console.ReadLine();
            switch (_currentUser.Role)
            {
                case UserRoleEnum.Standard:
                    _standardService.ChangePassword(_currentUser.Id, oldPassword, newPassword); 
                    break;
                case UserRoleEnum.Premium:
                    _premiumService.ChangePassword(_currentUser.Id, oldPassword, newPassword);
                    break;
                case UserRoleEnum.Trainer:
                    _trainerService.ChangePassword(_currentUser.Id, oldPassword, newPassword);
                    break;
            }
        }
        break;
    case "Log out":
        _currentUser = null;
        break;
}






Console.ReadLine();

void Seed()
{
    _standardService.Register(new StandardUser()
    {
        Firstname = "Bob",
        Lastname = "Bobski",
        Username = "bob.bobski",
        Password = "bob.bobski1"
    });
    _premiumService.Register(new PremiumUser()
    {
        Firstname = "Anne",
        Lastname = "Annesky",
        Username = "anne.annesky",
        Password = "anne.anesky1"
    });

    Trainer paul = new Trainer()
    {
        Firstname = "Paul",
        Lastname = "Pauleski",
        Username = "paul123",
        Password = "paul123",
        YearsOfExperince = 3
    };
    Trainer registerdTrainer = _trainerService.Register(paul);
    _videoTrainingServce.AddTraining(new VideoTraining()
    {
        Time = 15.14,
        Rating = 3,
        Link = "www.link.com",
        Title = "Abs workout",
        Description = "Abs workout made easy",
        Difficulty = TryBeingFit.Domain.Enums.TrainingDifficultyEnum.Easy
    });
    _videoTrainingServce.AddTraining(new VideoTraining()
    {
        Time = 10,
        Rating = 5,
        Link = "www.link.com",
        Title = "Cardio",
        Description = "Dance cardio",
        Difficulty = TryBeingFit.Domain.Enums.TrainingDifficultyEnum.Hard
    });
    _liveTrainingServce.AddTraining(new LiveTraining()
    {
        Time = 30,
        Rating = 5,
        Title = "Cardio",
        Description = "Dance cardio",
        Difficulty = TryBeingFit.Domain.Enums.TrainingDifficultyEnum.Medium,
        NextSession = DateTime.Now.AddDays(1)
    });
}