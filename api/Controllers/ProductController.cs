using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using api.Services;
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
        private readonly ProductService _productService;
        private readonly IMapper _mapper;        

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger, IMapper mapper, ProductService productService)
        {
            _productService = productService;
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetAll() {

            try {

                var response = _productService.GetAllProducts();
                return Ok(response);

            } catch (Exception ex) {

                return NotFound(ex.Message);
            }            
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetById(int id) {

            try {

                var response = _productService.GetProductById(id);
                return Ok(response);

            } catch (Exception ex) {
                return NotFound(ex.Message);
            }            
        }


        [HttpPost]
        public ActionResult<ProductResponse> Add([FromBody] ProductRequest request) {

            try {

                if (!ModelState.IsValid)                
                    return BadRequest(ModelState);                

                var response = _productService.CreateProduct(request);

                return Ok(response);
            } catch (Exception ex) {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ProductRequest request) {

            try {

                if (!ModelState.IsValid)                
                    return BadRequest(ModelState); 

                _productService.UpdateProduct(id, request);
                return NoContent();

            } catch (Exception e) {
                Debug.WriteLine(e);
                return NotFound();
            }            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            
            try {

                _productService.DeleteProduct(id);
                return NoContent();

            } catch (Exception ex) {
                return NotFound(ex.Message);
            }   
        }
    }
}