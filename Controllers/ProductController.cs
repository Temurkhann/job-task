using JobTask.Domain.Entities;
using JobTask.Service.DTOs;
using JobTask.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// create new product
        /// </summary>
        /// <param name="dto">product create</param>
        /// <returns>Created product infortaions</returns>
        /// <response code="200">If product is created successfully</response>
        [HttpPost, Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> CreateAsync(ProductForCreationDto dto) =>
            Ok(await productService.CreateAsync(dto));

        /// <summary>
        /// delete product by id (for only admins)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if product deleted succesfully else false</returns>
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<bool>> DeleteAsync([FromRoute] long id) =>
            Ok(await productService.DeleteAsync(product => product.Id == id));

        /// <summary>
        /// get all of products
        /// </summary>
        /// <param name="params">pagenation params</param>
        /// <returns> product collection </returns>
        [HttpGet, Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<IEnumerable<Product>>> GetAllAsync() =>
            Ok(await productService.GetAllAsync());

        /// <summary>
        /// get one product information
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>product</returns>
        /// <response code="400">if product data is not in the base</response>
        /// <response code="200">if product data have in database</response>
        //[HttpGet("{id}"), Authorize("AllPolicy")]
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<Product>> GetAsync([FromRoute] long id) =>
            Ok(await productService.GetAsync(p => p.Id == id));

        /// <summary>
        /// update product 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut, Authorize("Admin")]
        public async ValueTask<ActionResult<Product>> UpdateAsync(
            long id, [FromBody] ProductForCreationDto dto) =>
                Ok(await productService.UpdateAsync(id, dto));
    }
}
