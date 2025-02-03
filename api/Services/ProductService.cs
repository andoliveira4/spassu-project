using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using AutoMapper;

namespace api.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductResponse> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public ProductResponse GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return _mapper.Map<ProductResponse>(product);
        }

        public ProductResponse CreateProduct(ProductRequest request)
        {
            // Business logic: Convert name to uppercase and add 20% tax
            var product = _mapper.Map<Product>(request);
            product.Name = product.Name.ToUpper();
            product.Price *= 1.2m;

            _productRepository.Add(product);

            return _mapper.Map<ProductResponse>(product);
        }

        public void UpdateProduct(int id, ProductRequest request)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            // Business logic: Update product details
            _mapper.Map(request, existingProduct);
            existingProduct.Name = existingProduct.Name.ToUpper();
            existingProduct.Price *= 1.2m;

            _productRepository.Edit(existingProduct);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            _productRepository.Delete(id);
        }
    }
}