using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Repository;

namespace Занятие_3.Service
{
    public class ShopService : IShopService
    {
        //Todo: проверка на вводимые данные
        private readonly IDbRepository _dbRepository;
        public ShopService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<uint> Add(ShopEntity shop)
        {
            var result = await _dbRepository.Add(shop); // Добавляем в базу данных экземпляр модели Shop.
            #region ShopExtension
            if (shop ==null)
            {
                throw new ArgumentNullException("Пользователь не добавлен");
            }
            else if (string.IsNullOrWhiteSpace(shop.Name)|| shop.Name.Length<=1)
            {
                throw new ArgumentOutOfRangeException("Не верно задано имя магазина");
            }            
            #endregion
            await _dbRepository.SaveChangesAsync(); //Сохраняем изменения.
            return result;
        }

        public ShopEntity Get(uint id)
        {
            var entity = _dbRepository.Get<ShopEntity>().FirstOrDefault(x => x.Id == id); //По полученному из запроса Id находим запись в БД с идентичным Id
            return entity;
        }
        public async Task Delete(uint id)
        {
            await _dbRepository.Delete<ShopEntity>(id); //Убираем из всех будущих подборок экземпляр с Id, полученным из запроса.
            await _dbRepository.SaveChangesAsync();
        }

        

        public async Task<uint> Update(ShopEntity shop)
        {
            await _dbRepository.Update<ShopEntity>(shop); //Обновляем запись в БД
            await _dbRepository.SaveChangesAsync();
            return shop.Id;
        }

        #region Реализация без паттерна Репозиторий.
        //public int GetShopId(int id)
        //{            
        //    return id;
        //}
        //private readonly DataContext _context;
        //public async Task<string> SetShopName(ShopModel shop)
        //{

        //    var entity = await _context.Shops.AddAsync(shop);
        //    await _context.SaveChangesAsync();
        //    return shop.Name;
        //}


        //public ShopService(DataContext context)
        //{
        //    _context = context;

        //}
        //public Shop ShopInformation(Shop shop)
        //{
        //    return shop;
        //}
        #endregion
    }
}
