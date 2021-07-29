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

        public async Task<uint> Add(ProductEntity product)
        {
            //Set product`s category
            //product.ProductCategory.Products.Add(product);
            var result = await _dbRepository.Add(product);

            #region Product add exception

            if (product == null)
            {
                throw new ArgumentNullException("Товар не добавлен");
            }
            else if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length <= 1)
            {
                throw new ArgumentException("Не корректно задано имя товара");
            }
            else if (product.Price <= 0)
            {
                throw new ArgumentOutOfRangeException("Не корректно задана цена товара");
            }
            else if (product.ProductionDate >= DateTime.Now && product.ProductionDate == null)
            {
                throw new ArgumentOutOfRangeException("Указан не верный формат даты, либо не указан совсем");
            }
            else if (string.IsNullOrWhiteSpace(product.Manufacturer) || product.Manufacturer.Length <= 1)
            {
                throw new ArgumentOutOfRangeException("Не верно указана дата");
            }

            #endregion

            await _dbRepository.SaveChangesAsync();
            return result;

        }

        public ProductEntity Get(uint id)
        {
            var entity = _dbRepository.Get<ProductEntity>().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException("Такого товара не существует");
            }

            return entity;
        }

        public async Task Delete(uint id)
        {
            var CheckId = _dbRepository.Get<ProductEntity>().FirstOrDefault(x => x.Id == id);
            if (CheckId == null)
            {
                throw new ArgumentNullException("Order with this ID don`t exist");
            }

            await _dbRepository.Delete<ProductEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }



        public async Task<uint> Update(ProductEntity product)
        {
            await _dbRepository.Update<ProductEntity>(product);
            await _dbRepository.SaveChangesAsync();
            return product.Id;
        }
    }
}
