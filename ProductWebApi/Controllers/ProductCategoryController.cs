using Microsoft.AspNetCore.Mvc;
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
        // 1. Get all products
        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return Ok(products);
        }

        // 2. Get product by Id
        [HttpGet("products/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // 3. Create product
        [HttpPost("products")]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = _productRepository.AddProduct(product);

            return Ok(id);
        }

        // 4. Update product

        [HttpPut("products/{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _productRepository.GetProductById(id);

            if (existing == null)
                return NotFound();

            product.Id = id;

            _productRepository.UpdateProduct(product);

            return Ok(product);
        }

        // 5. Delete product
        [HttpDelete("products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existing = _productRepository.GetProductById(id);

            if (existing == null)
                return NotFound();

            _productRepository.DeleteProduct(id);

            return Ok("Product deleted successfully");
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
        public IActionResult UpdateCategoryProduct(int id, ProductCategory category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing =  _productCategoryRepository.GetProductCategoryById(id);

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