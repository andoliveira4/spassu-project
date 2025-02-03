using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;

namespace api.Repositories
{
    public class ProductRepository : IProductRepository
    {


        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        List<Product> _listProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Camiseta", Quantity = 99, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Active = true},
            new Product { Id = 2, Name = "Bola", Quantity = 99, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, Active = true},
        };

        public void Add(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();


            /*product.Id = _listProducts.Max(p => p.Id) + 1;
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            product.Active = true;
            _listProducts.Add(product);*/
        }

        public void Delete(int id)
        {
            /*var product = _listProducts.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _listProducts.Remove(product);
            }*/

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void Edit(Product product)
        {
            /*var existingProduct = _listProducts.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity = product.Quantity;
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.UpdatedAt = product.UpdatedAt;
                existingProduct.Active = product.Active;
            }*/

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
            //return _listProducts;
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
            //return _listProducts.FirstOrDefault(x => x.Id == id);
        }

    }
}