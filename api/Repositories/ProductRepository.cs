using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories
{
    public class ProductRepository : IProductRepository
    {

        List<Product> _listProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Camiseta", Quantity = 99, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Active = true},
            new Product { Id = 2, Name = "Bola", Quantity = 99, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Active = true},
        };

        public void Add(Product product)
        {
            product.Id = _listProducts.Max(p => p.Id) + 1;
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            product.Active = true;
            _listProducts.Add(product);
        }

        public void Delete(int id)
        {
            var product = _listProducts.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _listProducts.Remove(product);
            }
        }

        public void Edit(Product product)
        {
            var existingProduct = _listProducts.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _listProducts;
        }

        public Product getById(int id)
        {
            return _listProducts.FirstOrDefault(x => x.Id == id);
        }

    }
}