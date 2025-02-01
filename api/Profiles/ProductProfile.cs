using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using AutoMapper;

namespace api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Map from CreateProductRequest to Product
            CreateMap<ProductRequest, Product>();

            // Map from Product to ProductResponse
            CreateMap<Product, ProductResponse>();
        }
        
    }
}