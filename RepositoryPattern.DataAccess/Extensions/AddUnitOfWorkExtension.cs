using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.DataAccess.Interfaces;
using RepositoryPattern.DataAccess.Interfaces.Entities;
using RepositoryPattern.DataAccess.Repositories;
using RepositoryPattern.DataAccess.Repositories.Entities;

namespace RepositoryPattern.DataAccess.Extensions
{
    public static class AddUnitOfWorkExtension
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection service) 
        {
            service.AddTransient<IAuthorRepository, AuthorRepository>();
            service.AddTransient<IBookRepository, BookRepository>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
