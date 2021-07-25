using System;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Entities;
using ShopApi.Repository;

namespace ShopApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IDbRepository _dbRepository;
        public ProductService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<Guid> Add(ProductEntity product)
        {
            var result = await _dbRepository.Add(product); 
            
            if (product == null)
            {
                throw new NullReferenceException("Товар не добавлен");
            }
            
            if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length <= 1)
            {
                throw new ArgumentException("Не корректно задано имя товара");
            }
            
            if(product.Price <= 0)
            {
                throw new ArgumentOutOfRangeException("Не корректно задана цена товара");
            }
            
            if (string.IsNullOrWhiteSpace(product.Producer) || product.Producer.Length <= 1)
            {
                throw new NullReferenceException("Не верно указана дата");
            }                 

            await _dbRepository.SaveChangesAsync();
            return result;
        }
        public ProductEntity Get(Guid id)
        {
            var entity = _dbRepository.Get<ProductEntity>().FirstOrDefault(x => x.Id == id);
            
            if (entity ==null)
            {
                throw new NullReferenceException("Такого товара не существует");
            }
            
            return entity;
        }

        public async Task Delete(Guid id)
        {
            var checkId = _dbRepository.Get<ProductEntity>().FirstOrDefault(x => x.Id == id);
            
            if (checkId == null)
            {
                throw new NullReferenceException("Такого товара не существует");
            }
            
            await _dbRepository.Delete<ProductEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

        

        public async Task<Guid> Update(ProductEntity product)
        {
            await _dbRepository.Update(product);
            await _dbRepository.SaveChangesAsync();
            
            return product.Id;
        }
    }
}
