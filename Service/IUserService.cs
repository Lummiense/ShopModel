using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Service
{
    public interface IUserService
    {
        Task<Guid> Add(UserEntity user);
        UserEntity Get(Guid id);
        Task<Guid> Update(UserEntity user);
        Task Delete(Guid id);

        #region Реализация без паттерна Репозиторий.
        //string UserID { get; set; }
        //public string GetUserId(string id);
        //public User AddUser(User user);
        //public void DelUser(int id,User user);
        ////User UserInformation(User user);
        #endregion
    }
}
