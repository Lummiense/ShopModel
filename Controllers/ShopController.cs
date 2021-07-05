using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Занятие_3.Controllers
{
    [Route("shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("{id}")]
        public ActionResult<ShopEntity> Get(Guid id)
        {
            var _shop = _shopService.Get(id);

            if (_shop == null)
            {
                return BadRequest("Shop was not found");
            }

            return Ok(_shop);
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
            var result = await _shopService.Update(shop);

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
