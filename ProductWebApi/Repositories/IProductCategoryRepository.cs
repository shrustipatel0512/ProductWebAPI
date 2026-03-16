using ProductWebApi.Models;

namespace ProductWebApi.Repositories
{
    public interface IProductCategoryRepository
    {
        Task <List<ProductCategory>> GetAllProductCategories();
        Task<ProductCategory> GetProductCategoryById(int id);
        Task<ProductCategory> AddProductCategory(ProductCategory productCategory);
        Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory);
        Task<bool> DeleteProductCategory(int id);   
    }
}
