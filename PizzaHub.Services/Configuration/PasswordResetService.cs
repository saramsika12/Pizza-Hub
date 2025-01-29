using Microsoft.AspNetCore.Identity;
using PizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Configuration
{
    public class PasswordResetService
    {
        private readonly UserManager<User> _userManager;

        public PasswordResetService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> ResetPasswordAsync(string email, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false;
            }

            // Generate a reset token
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Use the token to reset the password
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

            return result.Succeeded;
        }
    }
}
