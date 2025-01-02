using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urwave.Core.Entities;

namespace Urwave.DataAccess.Repositories.Core;
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity entity);

    TEntity UpdateAsync(TEntity entity);

    TEntity Delete(TEntity entity);
}