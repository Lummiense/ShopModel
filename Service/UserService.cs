using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Model;
using Занятие_3.Repository;

namespace Занятие_3.Service
{
    //Todo: проверка на вводимые данные
    public class UserService : IUserService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(IDbRepository dbRepository, IConfiguration configuration, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        /// <summary>
        /// Аутентификация зарегистрированого пользователя.
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        public AuthenticationResponse Authentication(AuthenticationRequest Request)
        {
            //  var _user = _dbRepository.GetAll<UserEntity>()
            //      .FirstOrDefault(x => x.Login == Request.Username && x.Password == Request.Password);

            //  if (_user == null)
            //  {
            //      throw new ArgumentNullException("Такого пользователя не существует");
            //  }
            //  //Добавить генерацию токена
            //// var token = _configuration.
            return null;    
        }
        /// <summary>
        /// Регистрация нового пользователя.
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        public async Task<AuthenticationResponse> Registration(Buyer buyer)
        {
            var _buyer = _mapper.Map<UserEntity>(buyer);
            var AddBuyer =await _dbRepository.Add(_buyer);
            var Response = Authentication(new AuthenticationRequest
            {
                Username = _buyer.Login,
                //Password = _buyer.Password
            });
            return Response;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _dbRepository.GetAll<UserEntity>();
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
