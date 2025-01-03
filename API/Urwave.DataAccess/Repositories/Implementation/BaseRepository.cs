using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urwave.Core.Entities;
using Urwave.DataAccess.Persistence;
using Urwave.DataAccess.Repositories.Core;

namespace Urwave.DataAccess.Repositories.Implementation;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly UrwaveDbContext dbContext;

    public BaseRepository(UrwaveDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = await dbContext.Set<TEntity>().AddAsync(entity);

        return addedEntity.Entity;
    }

    public TEntity Delete(TEntity entity)
    {
        var removedEntity = dbContext.Set<TEntity>().Remove(entity);

        return removedEntity.Entity;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await dbContext.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public TEntity UpdateAsync(TEntity entity)
    {
        var UpdatedEntity = dbContext.Set<TEntity>().Update(entity);

        return UpdatedEntity.Entity;
    }
}