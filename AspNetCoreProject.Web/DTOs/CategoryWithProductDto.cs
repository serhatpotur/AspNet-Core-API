using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Web.DTOs
{
    public class CategoryWithProductDto:CategoryDto 
    {
        //Değişken tipi ve Değişken adı Category classında kş adı ile aynı olmalı   
        public ICollection<ProductDto> Products { get; set; }
    }
}
