using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Model;

namespace Занятие_3.Service
{
    public interface IUserService
    {
        AuthenticationResponse Authentication(AuthenticationRequest Request);
        Task<AuthenticationResponse> Registration(Buyer buyer);
        Task<uint> Add(UserEntity user);
        UserEntity Get(uint id);
        IEnumerable<UserEntity> GetAll();
        Task<uint> Update(UserEntity user);
        Task Delete(uint id);

        #region Реализация без паттерна Репозиторий.
        //string UserID { get; set; }
        //public string GetUserId(string id);
        //public User AddUser(User user);
        //public void DelUser(int id,User user);
        ////User UserInformation(User user);
        #endregion
    }
}
