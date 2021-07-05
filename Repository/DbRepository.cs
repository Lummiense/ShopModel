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
        /// Получаем выборку экземпляров с применением пред-фильтрации(список составляется после фильтрации)
        /// по типу активная-неактивная запись
        /// </summary>
        /// <typeparam name="модель объекта"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Get<T>() where T : class, IEntity
        {
            return _context.Set<T>().Where(x=>x.IsActive).AsQueryable();
        }

        /// <summary>
        /// Добавляем новый экземпляр класса в базу данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public async Task<Guid> Add<T>(T newEntity) where T : class, IEntity 
        {
           var entity = await _context.Set<T>().AddAsync(newEntity);                        
            
            return entity.Entity.Id;
        }

        /// <summary>
        /// Убираем экземпляр из подборок на отображение. При этом экземпляр остается в базе.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task  Delete<T>(Guid id) where T : class, IEntity
        {
            var activeEntity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id) ;
            activeEntity.IsActive = false;
            await Task.Run(() => _context.Update(activeEntity));
        }

        /// <summary>
        /// Удаляем из базы данных элемент по выбранному id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Remove<T>(T entity) where T : class
        {
             await Task.Run(() =>_context.Set<T>().Remove(entity));
        }
        
        /// <summary>
        /// Обновляем запись в базе данных.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update<T>(T entity) where T : class, IEntity //для чего в принципе используется Update?
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }
        
        /// <summary>
        /// Сохраняем изменения в базе данных.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
