using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.API.DTOs
{
    public  class CategoryDto
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
