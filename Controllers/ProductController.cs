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
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductEntity> Get(Guid id)
        {
            var _product = _productService.Get(id);

            if (_product == null)
            {
                return BadRequest("Product was not found");
            }

            return Ok(_product);
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
            var result = await _productService.Update(product);

            if (result == Guid.Empty)
            {
                return BadRequest("Product not updated");
            }

            return Ok(result);
        }

        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(Guid id)
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
