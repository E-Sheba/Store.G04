using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.Domain.Service.Contracts;
using Store.G04.Service.Services.Products;

namespace Store.G04.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            
            _productService = productService;
        }


        [HttpGet] // route is : BaseUrl / api / ControllerName (which is Products in this case)
        public async Task<IActionResult> GetAllProducts() //EndPoint its name is not important
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products); // ok is a helper method that returns the status code 200
        }


        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var Brands = await _productService.GetAllBrandsAsync();
            return Ok(Brands);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var types = await _productService.GetAllTypesAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int? id)
        {
            if (id == null) { return BadRequest("Invalid Id !!!!!!! -_-"); }
            var product = await _productService.GetProductByIdAsync(id.Value);
            if(product is null) return NotFound($"The Product with the given Id : {id} Doesn't exist in DB !");
            return Ok(product);
        }
    }
}
