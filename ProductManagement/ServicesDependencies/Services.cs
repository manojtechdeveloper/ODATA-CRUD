using ProductManagement.Service.IServices;
using ProductManagement.Service.Services;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.BaseRepository;
using ProductManagement.Repository.ProductDbContext;
namespace ProductManagement.ServicesDependencies
{
    public static class Services
    {
        public static void InjectServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAccountService, AccountService>();
        }
    }
}
