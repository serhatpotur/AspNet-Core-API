using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.API.DTOs
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductStock { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
