using Spectre.Console;
using UI.Views;
using Utilities.Helper;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var authView = new AuthView();
            var custView = new CustomerView();
            var adminView = new AdminView();
            while (true)
            {
                if (!SessionManager.IsLoggedIn())
                {
                    var options = new List<string> { "Login", "Register as Customer", "Quit" };
                    var choise = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Option: ").AddChoices(options));
                    switch (choise)
                    {
                        case "Login":
                            Console.Clear();
                            await authView.Login();
                            ClearConsole.ConsoleCleaner();
                            break;
                        case "Register as Customer":
                            Console.Clear();
                            await authView.Register();
                            ClearConsole.ConsoleCleaner();
                            break;
                        case "Quit":
                            return;
                    }
                }
                else
                {
                    if (!SessionManager.IsAdmin())
                    {
                        var custOptions = new List<string> { "View Available cars", "Rent Car", "View My Rentals", "Cancel Rentals", "Logout" };
                        var custChoise = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Options:").AddChoices(custOptions));
                        switch (custChoise)
                        {
                            case "View Available cars":
                                Console.Clear();
                                await custView.ViewAvailableCars();
                                ClearConsole.ConsoleCleaner();
                                break;
                            case "Rent Car":
                                Console.Clear();
                                await custView.RentCar();
                                ClearConsole.ConsoleCleaner();
                                break;
                            case "View My Rentals":
                                Console.Clear();
                                await custView.ViewMyRentals();
                                ClearConsole.ConsoleCleaner();
                                break;
                            case "Cancel Rentals":
                                Console.Clear();
                                await custView.CancelRent();
                                ClearConsole.ConsoleCleaner();
                                break;
                            case "Logout":
                                Console.Clear();
                                SessionManager.Logout();
                                break;
                        }
                    }
                    else
                    {
                        var adminOptions = new List<string> { "Add Car", "Toggle Car Active/Inactive","Show all records", "Logout" };
                        var adminChoise = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Option:").AddChoices(adminOptions));
                        switch (adminChoise)
                        {
                            case "Add Car":
                                Console.Clear();
                                await adminView.AddCarAsync();
                                ClearConsole.ConsoleCleaner();
                                break;
                            case "Toggle Car Active/Inactive":
                                Console.Clear();
                                await adminView.ToggleAsync();
                                ClearConsole.ConsoleCleaner();
                                break;
                            case "Show all records":
                                Console.Clear();
                                await adminView.ShowAllRecord();
                                ClearConsole.ConsoleCleaner();
                                break;
                            case "Logout":
                                Console.Clear();
                                SessionManager.Logout();
                                break;
                        }
                    }
                }
            }
        }
    }
}
