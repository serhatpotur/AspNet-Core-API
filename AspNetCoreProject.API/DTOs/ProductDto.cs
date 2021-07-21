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

        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1 değerinden büyük bir değer olmalıdır.")]
        public int ProductStock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} 1 değerinden büyük olmalıdır")]
        public decimal ProductPrice { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
