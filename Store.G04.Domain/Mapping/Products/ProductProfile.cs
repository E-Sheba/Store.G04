using AutoMapper;
using Store.G04.Domain.DTOs.Products;
using Store.G04.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Domain.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Here We Configure the navigational properties as they are not the same in the DTO class
            //We do that using ForMember method that exists in the IMappingExpression Interface
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.BrandName,
                options => options.MapFrom(s => s.Brand.Name))
                .ForMember(t => t.Name
                , options => options.MapFrom(s => s.Type.Name));



            CreateMap<ProductBrand, TypeBrandDTO>();



            CreateMap<ProductType, TypeBrandDTO>();
        }
    }
}
