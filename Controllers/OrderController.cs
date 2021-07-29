using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopApi.Entities;
using ShopApi.Model;
using ShopApi.Service;


namespace ShopApi.Controllers
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
        public ActionResult<OrderEntity> Get(uint id)
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
            if (_cartDTO.Id==null)
            {
                return BadRequest("Order not updated");
            }
            var result = await _orderService.Update(_cartDTO);

            

            return Ok(result);
        }

        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(uint id)
        {
            await _orderService.Delete(id);

            return Ok();
        }

       



    }
}
