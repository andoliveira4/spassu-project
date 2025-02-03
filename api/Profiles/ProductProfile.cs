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
            CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.ProductQuantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductPrice));

            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductQuantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price));
        }
        
    }
}