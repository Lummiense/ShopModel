using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Repository
{
    public class DbRepository : IDbRepository
    {
        private readonly DataContext _context;
        public DbRepository(DataContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Get all <T> -entities from base, filtered by active-status.
        /// </summary>
        /// <typeparam name></typeparam>
        /// <returns></returns>
        public IQueryable<T> Get<T>() where T : class, IEntity
        {
            return _context.Set<T>().Where(x=>x.IsActive).AsQueryable();
        }

        public List<T> GetAll<T>() where T : class,IEntity
        {
            return _context.Set<T>().ToList();
        }


        /// <summary>
        /// Add new entity to base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public async Task<uint> Add<T>(T newEntity) where T : class, IEntity 
        {
           var entity = await _context.Set<T>().AddAsync(newEntity);                        
            
            return entity.Entity.Id;
        }

        /// <summary>
        /// Set unavailable status for output by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task  Delete<T>(uint id) where T : class, IEntity
        {
            var activeEntity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id) ;
            activeEntity.IsActive = false;
            await Task.Run(() => _context.Update(activeEntity));
        }

        /// <summary>
        /// Remove from base by id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Remove<T>(T entity) where T : class
        {
             await Task.Run(() =>_context.Set<T>().Remove(entity));
        }
        
        /// <summary>
        /// Update database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update<T>(T entity) where T : class, IEntity //для чего в принципе используется Update?
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }
        
        /// <summary>
        /// Save changes in database.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
