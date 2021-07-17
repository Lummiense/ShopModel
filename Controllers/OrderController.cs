using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Model;
using Занятие_3.Service;

//TODO: Переделать передачу данных в Order из Entity в Model
namespace Занятие_3.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderEntity> Get(Guid id)
        {
            var _order = _orderService.Get(id);

            if (_order == null)
            {
                return BadRequest("Order was not found");
            }

            return Ok(_order);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OrderEntity>> Add(OrderEntity order)
        {
            var result = await _orderService.Add(order);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(OrderEntity order)
        {
            var result = await _orderService.Update(order);

            if (result == Guid.Empty)
            {
                return BadRequest("Order not updated");
            }

            return Ok(result);
        }

        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _orderService.Delete(id);

            return Ok();
        }

       



    }
}
