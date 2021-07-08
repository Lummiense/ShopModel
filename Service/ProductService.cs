﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Repository;

namespace Занятие_3.Service
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
            #region Product add exception
            if (product == null)
            {
                throw new ArgumentNullException("Товар не добавлен");
            }
            else if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length <= 1)
            {
                throw new ArgumentException("Не корректно задано имя товара");
            }
            else if(product.Price <=0)                    
            {
                throw new ArgumentOutOfRangeException("Не корректно задана цена товара");
            }
            else if (product.ProductionDate >=DateTime.Now && product.ProductionDate == null )
            {
                throw new ArgumentOutOfRangeException("Указан не верный формат даты, либо не указан совсем");
            }
            else if (string.IsNullOrWhiteSpace(product.Producer) || product.Producer.Length<=1)
            {
                throw new ArgumentOutOfRangeException("Не верно указана дата");
            }                 
                      
            #endregion
            await _dbRepository.SaveChangesAsync();
            return result;

        }
        public ProductEntity Get(Guid id)
        {
            var entity = _dbRepository.Get<ProductEntity>().FirstOrDefault(x => x.Id == id);
            if (entity ==null)
            {
                throw new ArgumentNullException("Такого товара не существует");
            }
            return entity;
        }

        public async Task Delete(Guid id)
        {
            var CheckId = _dbRepository.Get<ProductEntity>().FirstOrDefault(x => x.Id == id);
            if (CheckId == null)
            {
                throw new ArgumentNullException("Такого товара не существует");
            }
            await _dbRepository.Delete<ProductEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

        

        public async Task<Guid> Update(ProductEntity product)
        {
            await _dbRepository.Update<ProductEntity>(product);
            await _dbRepository.SaveChangesAsync();
            return product.Id;
        }

        #region Реализация без паттерна Репозиторий.
        //public int GetProductId(int Id)
        //{

        //    return Id;
        //}

        //public Product ProductInformation(Product product)
        //{
        //    return product;
        //}
        #endregion
    }
}