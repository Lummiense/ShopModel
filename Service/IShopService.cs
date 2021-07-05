using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Service
{
    public interface IShopService
    {
        Task<Guid> Add(ShopEntity shop);
        ShopEntity Get(Guid id);
        Task<Guid> Update(ShopEntity shop);
        Task Delete(Guid id);
        #region Реализация без паттерна Репозиторий.
        // int GetShopId(int id);
        //Task<string> SetShopName(ShopModel shop);
        ////Shop ShopInformation(Shop shop);
        #endregion
    }
}
