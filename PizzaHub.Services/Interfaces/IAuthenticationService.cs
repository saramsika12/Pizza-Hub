using PizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> CreateUserAsync(User user, string password, string role = "User");
        Task<bool> SignOut();
        Task<User> AuthenticateUserAsync(string Username, string Password);
        Task<User> GetUserAsync(string Username);
        Task<bool> ResetPasswordAsync(string email, string newPassword);
    }
}
