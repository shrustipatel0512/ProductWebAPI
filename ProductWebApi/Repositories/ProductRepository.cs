using Microsoft.EntityFrameworkCore;
using ProductWebApi.Data;
using ProductWebApi.Models;

namespace ProductWebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProdutWebApiDbContex _produtWebApiDbContex;

        public ProductRepository(ProdutWebApiDbContex produtWebApiDbContex)
        {
            _produtWebApiDbContex = produtWebApiDbContex;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _produtWebApiDbContex.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _produtWebApiDbContex.Products.FindAsync(id);
        }

        public async Task<Product> AddProduct(Product product)
        {
            _produtWebApiDbContex.Products.Add(product);
            await _produtWebApiDbContex.SaveChangesAsync();
            return product;
        }   

        public async Task<Product> UpdateProduct(Product product)
        {
            _produtWebApiDbContex.Products.Update(product);
            await _produtWebApiDbContex.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _produtWebApiDbContex.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _produtWebApiDbContex.Products.Remove(product);
            await _produtWebApiDbContex.SaveChangesAsync();
            return true;
        }
    }
}
