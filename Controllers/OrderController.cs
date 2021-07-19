using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Model;
using Занятие_3.Service;
using AutoMapper;


namespace Занятие_3.Controllers
{
    
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private readonly IMapper _mapper;       
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
       

        [HttpGet("{id}")]
        public ActionResult<OrderEntity> Get(Guid id)
        {
            
            var _order = _orderService.Get(id);
            if (_order == null)
            {
                return BadRequest("Order was not found");
            }
            var _orderDTO = _mapper.Map<Cart>(_order);
            return Ok(_orderDTO);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OrderEntity>> Add(Cart cart)
        {
            var _cartDTO = _mapper.Map<OrderEntity>(cart);
            var result = await _orderService.Add(_cartDTO);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Cart cart)
        {
            var _cartDTO = _mapper.Map<OrderEntity>(cart);
            var result = await _orderService.Update(_cartDTO);

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
