using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Urwave.Core.Entities;

namespace Urwave.DataAccess.Persistence;
public class UrwaveDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public UrwaveDbContext(DbContextOptions<UrwaveDbContext> options)
           : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }
}