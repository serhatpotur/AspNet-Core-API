using AspNetCoreProject.API.DTOs;
using AspNetCoreProject.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Category görürsen bunu CategoryDtoya dönüştür
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<CategoryDto, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, CategoryDto>();

            CreateMap<ProductDto, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, ProductDto>();
        }
    }
}
