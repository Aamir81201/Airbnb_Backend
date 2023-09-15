using Airbnb.DataModels.Data;
using Airbnb.DataModels.Models;
using Airbnb.Repository.Interface;
using Airbnb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Repository.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _context;
        public AuthRepository(AuthDbContext context)
        {
            _context = context;
        }

        //public bool IsEmailExists(string email)
        //{
        //    try
        //    {
        //        return _context.Users.Any(user => user.Email.ToLower() == email.ToLower());
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public UserAuthModel? UserLogin(UserLoginModel userLogin)
        //{
        //    var userAuth = _context.Users
        //        .Where(user => user.Email.ToLower() == userLogin.Email && user.Password == userLogin.Password)
        //        .Select(user => new UserAuthModel()
        //        {
        //            UserId = user.UserId,
        //            Email = user.Email,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Avatar = user.Avatar,
        //            Token = "123456789101112",
        //            TokenExpirationTimeSpan = new TimeSpan(1, 0, 0),
        //            Role = user.Role
        //        }).FirstOrDefault();

        //        return userAuth;
        //}

        //public string PreUserSignUp(UserSignUpModel userSignUp)
        //{
        //    if (_context.Users.Any(user => user.Email.ToLower() == userSignUp.Email.ToLower()))
        //    {
        //        if (_context.Users.Any(user => user.Email.ToLower() == userSignUp.Email.ToLower() && user.Password == userSignUp.Password))
        //        {
        //            return "login";
        //        }
        //        return "password";
        //    }

        //    return "signUp";
        //}

        //public UserAuthModel UserSignUp(UserSignUpModel userSignUp)
        //{
        //    var newUser = new ApplicationUser()
        //    {
        //        FirstName = userSignUp.FirstName,
        //        LastName = userSignUp.LastName,
        //        Email = userSignUp.Email,
        //        Password = userSignUp.Password,
        //        DateOfBirth = DateTime.Now,
        //        Avatar = null,
        //        RecieveMarketingMessages = userSignUp.RecieveMarketingMessages,
        //        Role = "User"
        //    };

        //    _context.Users.Add(newUser);

        //    _context.SaveChanges();

        //    return new UserAuthModel()
        //    {
        //        UserId = newUser.UserId,
        //        FirstName = newUser.FirstName,
        //        LastName = newUser.LastName,
        //        Email = newUser.Email,
        //        Token = "123456789101112",
        //        TokenExpirationTimeSpan = new TimeSpan(1, 0, 0),
        //        Avatar = newUser.Avatar,
        //        Role = newUser.Role
        //    };
        //}



        //public List<UserProfileModel> GetUserProfiles(List<string> userIds)
        //{
        //    try
        //    {
        //        return _context.Users.Where(user => userIds.Contains(user.UserId.ToString())).Select(user => new UserProfileModel()
        //        {
        //            UserId = user.UserId,
        //            Name = user.FirstName,
        //            Email = user.Email,
        //            Avatar = user.Avatar
        //        }).ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
