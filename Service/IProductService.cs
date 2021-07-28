using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Service
{
    public interface IProductService
    {
        Task<uint> Add(ProductEntity product);
        ProductEntity Get(uint id);
        Task<uint> Update(ProductEntity product);
        Task Delete(uint id);
        #region Реализация без использования паттерна Репозиторий.
        //public int GetProductId(int id); 
        #endregion

    }
}
