using BuisnessLayer.Interface;
using BuisnessLayer.Service;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Views
{
    public class AuthView
    {
        IUserService _userService;
        public AuthView()
        {
            _userService = new UserService();
        }
        public async Task Register()
        {
            Console.WriteLine("Enter detials to register: ");
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter you Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your phone number: ");
            string phone = Console.ReadLine();
            string userError =await _userService.RegisterAsync(email, password,name ,phone);
            if (userError != Messages.UserRegisteredSuccessfull)
            {
                Console.WriteLine(userError);
                return;
            }
            Console.WriteLine(userError);

        }
        public async Task Login()
        {
            Console.WriteLine("Enter detials to login: ");
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password : ");
            string password = Console.ReadLine();
            var userError = await _userService.LoginUser(email, password);
            if(!userError.Success)
            {
                Console.WriteLine(userError.Message);
                return;
            }
            Console.WriteLine(userError.Message);
        }
    }
}
