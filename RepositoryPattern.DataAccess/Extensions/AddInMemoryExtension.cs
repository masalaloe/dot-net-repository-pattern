using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.DataAccess.InMemory;

namespace RepositoryPattern.DataAccess.Extensions
{
    public static class AddInMemoryExtension
    {
        public static IServiceCollection AddInMemoryContext(this IServiceCollection service) => 
            service.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"));
    }
}
