using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.BaseRepository;
using ProductManagement.Repository.ProductDbContext;

namespace ProductManagement.RepositoryDependencies
{
    public static class Repositories
    {
        public static void InjectRepositories(WebApplicationBuilder builder)
        {
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(
   connection));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
