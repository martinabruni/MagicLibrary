using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Infrastructure.Models;
using MagicLibrary.Core.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services, IConfiguration configurations)
        {
            services.AddDbContext<SqldbMagiclibraryCoreDevContext>(options =>
            {
                options.UseSqlServer(configurations.GetConnectionString("Sql"));
            });
            services.AddScoped<IRepository<AuthorEntity>, AuthorRepository>();
            services.AddScoped<IRepository<BookEntity>, BookRepository>();
            services.AddScoped<IRepository<BookLoanEntity>, BookLoanRepository>();
            services.AddScoped<IRepository<UserEntity>, UserRepository>();
            return services;
        }
    }
}
