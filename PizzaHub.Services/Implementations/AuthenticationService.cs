using Microsoft.AspNetCore.Identity;
using PizzaHub.Entities;
using PizzaHub.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<User> _signManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;

        public AuthenticationService(SignInManager<User> signManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signManager;
        }
       

        //public User GetUser(string Username)
        //{
        //    return _userManager.FindByNameAsync(Username).Result;
        //}

        public async Task<bool> SignOut()
        {
            try
            {
                await _signManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<User> GetUserAsync(string Username)
        {
            return _userManager.FindByNameAsync(Username);
        }

        public async Task<User> AuthenticateUserAsync(string Username, string Password)
        {
            var result = await _signManager.PasswordSignInAsync(Username, Password,
               false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(Username);
                var roles = await _userManager.GetRolesAsync(user);
                user.Roles = roles.ToArray();

                return user;
            }
            return null;
        }

        public async Task<bool> CreateUserAsync(User user, string password, string role = "User")
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                ////Admin, User
                //string role = "Admin";
                //var res = _userManager.AddToRoleAsync(user, role).Result;
                //if (res.Succeeded)
                //{
                //    return true;
                //}
                var roleResult = await _userManager.AddToRoleAsync(user, role);

                if (roleResult.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ResetPasswordAsync(string email, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

            return result.Succeeded;
        }
    }
}
