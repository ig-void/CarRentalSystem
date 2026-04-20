using BuisnessLayer.Interface;
using BuisnessLayer.Mapper;
using DataAccess.Entities;
using DataAccess.Interface;
using DataAccess.Repository;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using Utilities.Helper;
using Utilities.MailSender;


namespace BuisnessLayer.Service
{
    public class UserService : IUserService
    {
        IUserRepository _userRepo;
        ICustomerRepository _custRepo;
        public UserService()
        {
            _userRepo = new UserRepository();
            _custRepo = new CustomerRepository();
        }

        public async Task<Result<User>> LoginUser(string email, string password)
        {
            string emailError = EmailValidator.ValidateEmail(email);
            if (emailError != null) return new Result<User> { Success =false , Message = Messages.InvalidEmail};
            var existing =await  _userRepo.GetUserByEmail(email);
            if (existing == null) return new Result<User> { Success= false, Message = Messages.UserNotFound};
            if (existing.Password != password) return new Result<User> { Success = false, Message = Messages.IncorrectPass };
            SessionManager.Login(existing);
            return new Result<User> {Success =true , Message = Messages.Login, Data=existing};
        }

        public async Task<string> RegisterAsync(string email, string password,string name ,string phone)
        {
            string emailError = EmailValidator.ValidateEmail(email);
            if(emailError != null) return emailError;
            User user = new User { Email = email, Password = password };
            string phoneError = PhoneValidator.ValidatePhone(phone);
            if(phoneError != null) return phoneError;
            var existing =await _userRepo.GetUserByEmail(email);
            if (existing != null) return Messages.UserAlreadyPresent;
            await _userRepo.AddAsync(user);
            User user1 = await _userRepo.GetUserByEmail(email);
            Customer customer = new Customer { UserId=user1.Id,Name= name , PhoneNumber= phone } ;
            await _custRepo.AddAsync(customer);
            var cust = await _custRepo.GetByUserIdAsync(user1.Id);
            var custData = UserToCustomerMapper.ToDto(cust);
            var mailResult =await RegisteredUserSender.SendMail(custData);
            Console.WriteLine(mailResult);
            return Messages.UserRegisteredSuccessfull;
        }
    }
}
