using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProject.Web.DTOs;

namespace AspNetCoreProject.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            /*
             * Api katmanı eklediğimiz için artık Service katmanı ile haberleşmiyoruz. Bu alana artık gerek yok
             * 
            //Category görürsen bunu CategoryDtoya dönüştür

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>(); */
        }



    }
}
