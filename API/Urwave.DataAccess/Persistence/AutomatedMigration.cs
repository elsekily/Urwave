using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urwave.DataAccess.Repositories.Core;
using Urwave.DataAccess.UnitOfWork;

namespace Urwave.DataAccess.Persistence;
public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<UrwaveDbContext>();
            await context.Database.MigrateAsync();

            var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await DatabaseSeed.SeedUsersAndRolesAsync(productRepository);
            await unitOfWork.CommitAsync();
        }
    }
}