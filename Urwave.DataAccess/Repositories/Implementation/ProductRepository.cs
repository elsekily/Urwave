using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urwave.Core.Entities;
using Urwave.DataAccess.Persistence;
using Urwave.DataAccess.Repositories.Core;

namespace Urwave.DataAccess.Repositories.Implementation;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(UrwaveDbContext dbContext) : base(dbContext)
    {
    }
}