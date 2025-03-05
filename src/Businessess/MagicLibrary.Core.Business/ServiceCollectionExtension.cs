using MagicLibrary.Core.Business.Mappers;
using MagicLibrary.Core.Business.Services;
using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreBusiness(this IServiceCollection services)
        {
            services.AddScoped<IMapper<UserEntity, User>, UserMapper>();
            services.AddScoped<IMapper<BookEntity, Book>, BookMapper>();
            services.AddScoped<IMapper<BookLoanEntity, BookLoan>, BookLoanMapper>();
            services.AddScoped<IMapper<AuthorEntity, Author>, AuthorMapper>();

            services.AddScoped<IService<User, UserEntity>, UserService>();
            services.AddScoped<IService<Book, BookEntity>, BookService>();
            services.AddScoped<IService<BookLoan, BookLoanEntity>, BookLoanService>();
            services.AddScoped<IService<Author, AuthorEntity>, AuthorService>();
            return services;
        }
    }
}
