using AutoMapper;
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
    [Route("shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private IShopService _shopService;
        private readonly IMapper _mapper;
        public ShopController(IShopService shopService, IMapper mapper)
        {
            _shopService = shopService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<ShopEntity> Get(Guid id)
        {
            var _shop = _shopService.Get(id);

            if (_shop == null)
            {
                return BadRequest("Shop was not found");
            }
            var _shopDTO = _mapper.Map<ShopForBuyers>(_shop);

            return Ok(_shopDTO);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ShopEntity>> Add(ShopForBuyers _shop)
        {
            var _shopDTO = _mapper.Map<ShopEntity>(_shop);
            var result = await _shopService.Add(_shopDTO);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ShopForBuyers _shop)
        {
            var _shopDTO = _mapper.Map<ShopEntity>(_shop);
            var result = await _shopService.Update(_shopDTO);

            if (result == Guid.Empty)
            {
                return BadRequest("Shop not updated");
            }

            return Ok(result);
        }

        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _shopService.Delete(id);

            return Ok();
        }

        #region Реализация без паттерна Репозиторий.
        //// GET api/<ShopControler>/{id}
        //[HttpGet("{id}")]
        //public IActionResult GetShop(int id)
        //{
        //    var ShopID = _shop.GetShopId(id);
        //    return Ok(ShopID);
        //}

        //// POST api/<ShopControler>/create 
        //[HttpPost("create")]
        //public async Task<IActionResult> Post([FromBody] ShopModel shop)
        //    => Ok(await _shop.SetShopName(shop));
        #endregion



    }
}
