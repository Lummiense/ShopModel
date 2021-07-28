using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Service
{
    public interface IShopService
    {
        Task<uint> Add(ShopEntity shop);
        ShopEntity Get(uint id);
        Task<uint> Update(ShopEntity shop);
        Task Delete(uint id);
        #region Реализация без паттерна Репозиторий.
        // int GetShopId(int id);
        //Task<string> SetShopName(ShopModel shop);
        ////Shop ShopInformation(Shop shop);
        #endregion
    }
}
