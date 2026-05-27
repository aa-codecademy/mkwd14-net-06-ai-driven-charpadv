using TaxiManager9000.Helpers;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Services.Services;

namespace TaxiManager9000.App
{
    internal class TaxiManagerUI
    {
        private readonly IUIService _uiService;

        public TaxiManagerUI()
        {
            _uiService = new UIService();
        }

        public void InitApp()
        {
            while (true)
            {
                Console.Clear();
                #region Login Menu

                try
                {
                    ConsoleHelper.PrintTitle("\n\t*** Taxi Manager 9000 ***\n");
                    //int choice = _uiService.ChooseMenu(new List<string> { "Login", "Exit" });
                    int choice = _uiService.ChooseMenu(["Login", "Exit"]);
                    if (choice == -1)
                    {
                        ConsoleHelper.PrintError("Invalid choice! Try again.");
                        continue;
                    }
                    if (choice == 2) break;

                    // Login Menu ... to be continued...
                }
                catch (Exception ex)
                {
                    ConsoleHelper.PrintError(ex.ToString());
                    continue;
                }
            }

            #endregion
        }
    }
}
