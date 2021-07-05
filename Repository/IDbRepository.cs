using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Repository
{
    public interface IDbRepository
    {
        IQueryable<T> Get<T>() where T : class, IEntity;
        Task<Guid> Add<T>(T newEntity) where T : class,IEntity;
        Task Delete<T>(Guid id) where T : class, IEntity;
        Task Remove <T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class,IEntity;
        Task<int> SaveChangesAsync();

    }
}
