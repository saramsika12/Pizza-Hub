using PizzaHub.Entities;
using System.Threading.Tasks;

namespace PizzaHub.WebUI.Interfaces
{
    public interface IUserAccessor
    {

        Task<User> GetUserAsync();

        //User GetUser();
    }
}
