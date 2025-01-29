using Microsoft.Extensions.DependencyInjection;
using PizzaHub.Services.Configuration;
using PizzaHub.Services.Implementations;
using PizzaHub.Services.Interfaces;
using PizzaHub.WebUI.Helpers;
using PizzaHub.WebUI.Interfaces;

namespace PizzaHub.WebUI.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IUserAccessor, UserAccessor>();

            services.AddTransient<ICatalogService, CatalogService>();

            services.AddTransient<ICartService, CartService>();

            services.AddTransient<IFileHelper, FileHelper>();

            services.AddScoped<PasswordResetService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
