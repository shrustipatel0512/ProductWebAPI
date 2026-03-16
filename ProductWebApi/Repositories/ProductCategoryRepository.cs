using Microsoft.EntityFrameworkCore;
using ProductWebApi.Data;
using ProductWebApi.Models;

namespace ProductWebApi.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProdutWebApiDbContex _produtWebApiDbContex;

        public ProductCategoryRepository(ProdutWebApiDbContex produtWebApiDbContex)
        {
            _produtWebApiDbContex = produtWebApiDbContex;
        }

        public async Task<List<ProductCategory>> GetAllProductCategories()
        {
            return await _produtWebApiDbContex.ProductCategories.ToListAsync();
        }
        public async Task<ProductCategory> GetProductCategoryById(int id)
        {
            return await _produtWebApiDbContex.ProductCategories.FindAsync(id);
        }
        public async Task<ProductCategory> AddProductCategory(ProductCategory productCategory)
        {
            _produtWebApiDbContex.ProductCategories.Add(productCategory);
            await _produtWebApiDbContex.SaveChangesAsync();
            return productCategory;
        }
        public async Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory)
        {
            _produtWebApiDbContex.ProductCategories.Update(productCategory);
            await _produtWebApiDbContex.SaveChangesAsync();
            return productCategory;
        }

        public async Task<bool> DeleteProductCategory(int id)
        {
            var productCategory = await _produtWebApiDbContex.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return false;
            }
            _produtWebApiDbContex.ProductCategories.Remove(productCategory);
            await _produtWebApiDbContex.SaveChangesAsync();
            return true;
        }


    }
}
