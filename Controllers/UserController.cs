using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Model;
using Занятие_3.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Занятие_3.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserControler : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserService _userService;

        public UserControler(IMapper mapper, IUserService _user)
        {
            _mapper = mapper;
            _userService = _user;
        }

       
        //[Authorize]
        [HttpGet("{id}")]
        //TODO: Передать в качестве типа данных модель пользователя после мапинга       
        public ActionResult<UserEntity> Get(uint id)
        {
       //     id = uint.Empty;
            var _user = _userService.Get(id);

            if (_user == null)
            {
                return BadRequest("User was not found");
            }
            var _userDTO = _mapper.Map<Buyer>(_user);
            return Ok(_userDTO);
        }
        //[Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<UserEntity>> Add(UserEntity user)
        {
            
            var result = await _userService.Add(user);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UserEntity user)
        {
            
            
            if (user.Id <0)
            {
                return BadRequest("Id must be positive");
            }
            var result = await _userService.Update(user);

            

            return Ok(result);
        }

        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(uint id)
        {
            await _userService.Delete(id);

            return Ok();
        }

        #region Вариации c атрибутами
        //// GET api/<UserControler>/{id} . Берем значение id из URL
        //[HttpGet("{GetId}")]
        //public IActionResult GetUsers(
        //    [FromRoute] string GetId)
        //{
        //    var UserId = getUser.GetUserId(GetId);
        //    return Ok(UserId);
        //}        

        //// POST api/<TestControler>/user/create
        //[HttpPost("user/create")]
        //public IActionResult Post(User user)
        //{
        //    user.Name = "Mike";
        //    getUser.AddUser(user);
        //    return Ok(user.Name);
        //}

        //// DELETE api/<TestControler>/user/delete/{id} .
        //[HttpDelete("/user/delete/{id}")]
        //public IActionResult Delete(
        //    [FromRoute]int id,
        //    User user)
        //{        
        //    getUser.DelUser(id,user);            
        //    return Ok();
        //}
        #endregion
    }
}
