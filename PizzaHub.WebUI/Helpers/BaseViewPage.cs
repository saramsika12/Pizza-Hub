using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using PizzaHub.Entities;
using PizzaHub.WebUI.Interfaces;
using System.Threading.Tasks;

namespace PizzaHub.WebUI.Helpers
{
    public abstract class BaseViewPage<TModel>: RazorPage<TModel>
    {
        [RazorInject]
        public  IUserAccessor _userAccessor {  get; set; }
        public User CurrentUser 
        { 
            get 
            {
                if (User.Identity.IsAuthenticated)
                    return _userAccessor.GetUserAsync().Result;
                else
                    return null;
            } 
        }
        public async Task<User> GetCurrentUserAsync()
        {
            return await _userAccessor.GetUserAsync();
        }

    }
}
