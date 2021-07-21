using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.API.DTOs
{
    public class ProductWithCategoryDto
    {
        public CategoryDto Category { get; set; }
    }
}
