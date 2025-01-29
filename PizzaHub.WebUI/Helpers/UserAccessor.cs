using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PizzaHub.Entities;
using PizzaHub.WebUI.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PizzaHub.WebUI.Helpers
{
    public class UserAccessor: IUserAccessor
    {
        private readonly UserManager<User> _userAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UserAccessor(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userAccessor = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

       

        public async Task<User> GetUserAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
                return null;

            // Get the user ID from the claims
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _userAccessor.FindByIdAsync(userId);
        }


        //public User GetUser()
        //{
        //    if (_httpContextAccessor.HttpContext.User == null)
        //        return _userAccessor.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
        //    else
        //        return null;
        //}
    }
}
