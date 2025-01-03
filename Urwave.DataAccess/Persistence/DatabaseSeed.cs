using Urwave.Core.Entities;
using Urwave.DataAccess.Repositories.Core;

namespace Urwave.DataAccess.Persistence;

public class DatabaseSeed
{
        public static async Task SeedUsersAndRolesAsync(IProductRepository productRepository)
        {
            if (!(await productRepository.GetAllAsync()).Any())
            {
                var products = new List<Product>()
                {
                    new Product() { Name = "Product1", Description = "This is Description1 for Product1", Price = 10.00, CreatedOn = DateTime.Now },
                    new Product() { Name = "Product2", Description = "This is Description2 for Product2", Price = 15.00, CreatedOn = DateTime.Now },
                    new Product() { Name = "Product3", Description = "This is Description3 for Product3", Price = 20.00, CreatedOn = DateTime.Now }
                };
                foreach (var product in products)
                {
                    await productRepository.AddAsync(product);
                }
            }
        }
}