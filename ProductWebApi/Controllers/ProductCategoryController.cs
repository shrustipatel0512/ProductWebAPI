using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Dtos;
using ProductWebApi.Models;
using ProductWebApi.Repositories;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IProductRepository _productRepository;

        public ProductCategoryController(IProductCategoryRepository productCategoryRepository, IProductRepository productRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }
        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await  _productRepository.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(CreateProductDto input)
        {
            var result = await _productRepository.AddProduct(input);
            return Ok(result);
        }


        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _productRepository.GetProductById(id);

            if (existing == null)
                return NotFound();

            product.Id = id;

            _productRepository.UpdateProduct(product);

            return Ok(product);
        }

        // 5. Delete product
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productRepository.DeleteProduct(id);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

         [HttpGet]
        public async Task<IActionResult> GetProdutategoryResult()
        {
            var data = await _productCategoryRepository.GetAllProductCategories();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductategoryById(int id)
        {
            var produ = await _productCategoryRepository.GetProductCategoryById(id);

            if (produ == null)
                return NotFound();
            return Ok(produ);
        }
        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> CreateCategoryProduct(ProductCategory category)
        {
            try
            {
                var data = await _productCategoryRepository.AddProductCategory(category);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // ✅ only your message
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryProduct(int id, ProductCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing =  await _productCategoryRepository.GetProductCategoryById(id);

            if (existing == null)
                return NotFound();

            category.Id = id;

            _productCategoryRepository.UpdateProductCategory(category);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryProduct(int id)
        {
            var isDeleted = await _productCategoryRepository.DeleteProductCategory(id);

            if (!isDeleted)
                return NotFound();

            return NoContent(); // ✅ best practice (204)
        }


    }
}