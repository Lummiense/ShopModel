using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Entities;
using ShopApi.Model;
using ShopApi.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopApi.Controllers
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
        public ActionResult<ShopEntity> Get(uint id)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return BadRequest("Shop was not found");
            }
            var _shopDTO = _mapper.Map<ShopForBuyers>(shop);

            return Ok(_shopDTO);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ShopEntity>> Add(ShopEntity shop)
        {
            
            var result = await _shopService.Add(shop);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ShopEntity shop)
        {
            
            if (shop.Id <0 )
            {
                return BadRequest("Id must be positive");
            }
            var result = await _shopService.Update(shop);

            

            return Ok(result);
        }

        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(uint id)
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
