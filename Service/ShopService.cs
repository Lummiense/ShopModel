using System;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Entities;
using ShopApi.Repository;

namespace ShopApi.Service
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
    }
}
