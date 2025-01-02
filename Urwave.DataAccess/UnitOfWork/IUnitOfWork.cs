using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urwave.DataAccess.Persistence;

namespace Urwave.DataAccess.UnitOfWork;
public interface IUnitOfWork
{
    Task CommitAsync();
}
public class UnitOfWork : IUnitOfWork
{
    private readonly UrwaveDbContext context;

    public UnitOfWork(UrwaveDbContext context)
    {
        this.context = context;
    }
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}