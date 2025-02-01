using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() {

            try {
                var product = _productRepository.GetAll();
                return Ok(product);
            } catch (Exception e) {

                Debug.WriteLine(e);
                return NotFound();
            }            
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id) {

            try {
                var product = _productRepository.getById(id);
                return Ok(product);
            } catch (Exception e) {
                Debug.WriteLine(e);
                return NotFound();
            }            
        }


        [HttpPost]
        public ActionResult<Product> Add(ProductRequest request) {

            try {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price
                };


                _productRepository.Add(product);
                return Ok(product);
            } catch (Exception e) {

                Debug.WriteLine(e);
                return NotFound();
            }
            
        }

        [HttpPut]
        public ActionResult<Product> Update(int id, ProductRequest request) {

            try {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                /*if (id != product.Id)
                {
                    return BadRequest();
                }*/

                if (_productRepository.getById(id) == null)
                {
                    return NotFound();
                }

                var product = new Product
                {
                    Id = id,
                    Name = request.Name,
                    Price = request.Price
                };

                var existingProduct = _productRepository.getById(product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }

                return Ok(product);
            } catch (Exception e) {
                Debug.WriteLine(e);
                return NotFound();
            }            
        }

        [HttpDelete] 
        public ActionResult Delete(int id) {
            
            try {
                _productRepository.Delete(id);
                return NoContent();

            } catch (Exception e) {
                Debug.WriteLine(e);
                return NotFound();
            }   
        }
    }
}