using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaHub.Entities;
using PizzaHub.Repositories;
using PizzaHub.Repositories.Implementations;
using PizzaHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Configuration
{
    public class ConfigureRepositories
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString
                    ("DefaultConnection"));
            });
            services.AddIdentity<User, Role>().
               AddEntityFrameworkStores<AppDbContext>
               ().AddDefaultTokenProviders();
            //register AppDbContext as the DbContext           
            services.AddScoped<DbContext, AppDbContext>();

            //register repositories with appropriate lifetime
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IRepository<Item>, Repository<Item>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<ItemType>, Repository<ItemType>>();
            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();

            //Add identity-related services
           
        }
    }
}
