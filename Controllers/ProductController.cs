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
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductEntity> Get(uint id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return BadRequest("Product was not found");
            }
            var _productDTO = _mapper.Map<ProductForBuyer>(product);
            return Ok(_productDTO);
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProductEntity>> Add(ProductEntity product)
        {
            
            var result = await _productService.Add(product);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductEntity product)
        {
            
            if (product.Id<0)
            {
                return BadRequest("Product not updated");
            }
            var result = await _productService.Update(product);

            

            return Ok(result);
        }

        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(uint id)
        {
            await _productService.Delete(id);

            return Ok();
        }


        #region Реализация без паттерна Репозиторий.
        //// GET api/<TestControler>/product/{id} .Берем id из url, применяя фильтр по ключевому слову "id".
        //[HttpGet("product/")]
        //public IActionResult GetProduct
        //    ([FromQuery(Name = "id")] int Id,
        //    [FromServices] IProduct product) => Ok(product.GetProductId(Id));

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
}
