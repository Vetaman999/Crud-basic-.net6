using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba.Domain.Models;
using prueba.Domain.Services;
using prueba.Extensions;
using prueba.Resources;

namespace prueba.Controllers
{
    [Route("api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /*****************************************************************/
        /*                         LIST OF USERS                         */
        /*****************************************************************/

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResource>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        /*****************************************************************/
                                /*GET ARTIST BY ID*/
        /*****************************************************************/

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByIdAsync(long productId)
        {
            var result = await _productService.GetByIdAsync(productId);
            if (!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /*****************************************************************/
        /*GET ARTIST BY NAME*/
        /*****************************************************************/

        [HttpGet("/name/{name}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = await _productService.GetByNameAsync(name);
            if (!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /*****************************************************************/
        /*SAVE ARTIST*/
        /*****************************************************************/

        [HttpPost]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }


        /*****************************************************************/
        /*UPDATE ARTIST*/
        /*****************************************************************/

        [HttpPut("{productId}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(long productId, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(productId, product);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }



        /*****************************************************************/
        /*DELETE ARTIST*/
        /*****************************************************************/

        [HttpDelete("{productId}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(long productId)
        {
            var result = await _productService.DeleteAsync(productId);
            if (!result.Success)
                return BadRequest(result.Message);
            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }
    }
}
