using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Repository;

namespace Занятие_3.Service
{
    //Todo: проверка на вводимые данные
    public class UserService : IUserService
    {
        private readonly IDbRepository _dbRepository;
        public UserService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<Guid> Add(UserEntity user)
        {
            var result =await _dbRepository.Add(user) ;
            #region UserException
            if (result ==null)
            {
                throw new ArgumentException("Пользователь не добавлен");
            }
            else if (string.IsNullOrWhiteSpace(user.Name)||user.Name.Length<=1)
            {
                throw new ArgumentOutOfRangeException("Не верный формат имени пользователя");
            }
            #endregion

            await _dbRepository.SaveChangesAsync();
            return result;
        }

        public UserEntity Get(Guid id)
        {
            var entity = _dbRepository.Get<UserEntity>().FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public async Task<Guid> Update(UserEntity user)
        {
            await _dbRepository.Update<UserEntity>(user);
            await _dbRepository.SaveChangesAsync();

            return user.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<UserEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }


        #region Реализация без паттерна Репозиторий.
        //string userID;
        //List<User> UserList = new List<User>();

        //public string UserID
        //{
        //    get
        //    {
        //        return userID;
        //    }
        //    set
        //    {
        //        userID = value;
        //    }
        //}
        //public string GetUserId(string id)
        //{
        //    id = UserID;
        //    return UserID;
        //}
        //public User AddUser(User user)
        //{

        //    UserList.Add(user);
        //    return user;
        //}
        //public void DelUser (int id,User user)
        //{
        //    UserList.Add(user);
        //    user.Id = id;
        //    UserList.Remove(user);
        //}




        //public User UserInformation(User user)
        //{
        //    return user;
        //}
        #endregion
    }
}
