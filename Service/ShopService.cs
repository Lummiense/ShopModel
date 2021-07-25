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

        public async Task<Guid> Add(ShopEntity shop)
        {
            // Добавляем в базу данных экземпляр модели Shop.
            var result = await _dbRepository.Add(shop); 

            if (shop == null)
            {
                throw new NullReferenceException("Пользователь не добавлен");
            }

            if (string.IsNullOrWhiteSpace(shop.Name) || shop.Name.Length <= 1)
            {
                throw new NullReferenceException("Не верно задано имя магазина");
            }

            //Сохраняем изменения.
            await _dbRepository.SaveChangesAsync(); 

            return result;
        }

        public ShopEntity Get(Guid id)
        {
            //По полученному из запроса Id находим запись в БД с идентичным Id
            var entity = _dbRepository.Get<ShopEntity>().FirstOrDefault(x => x.Id == id); 
            
            return entity;
        }
        
        public async Task Delete(Guid id)
        {
            //Убираем из всех будущих подборок экземпляр с Id, полученным из запроса.
            await _dbRepository.Delete<ShopEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task<Guid> Update(ShopEntity shop)
        {
            //Обновляем запись в БД
            await _dbRepository.Update(shop);
            await _dbRepository.SaveChangesAsync();
            
            return shop.Id;
        }
    }
}
