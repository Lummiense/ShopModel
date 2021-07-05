using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Service
{
    public interface IProductService

    {
        Task<Guid> Add(ProductEntity product);
        ProductEntity Get(Guid id);
        Task<Guid> Update(ProductEntity product);
        Task Delete(Guid id);
        #region Реализация без использования паттерна Репозиторий.
        //public int GetProductId(int id); 
        #endregion

    }
}
