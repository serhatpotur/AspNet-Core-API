using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Web.DTOs
{
    public  class CategoryDto
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="{0} alanı boş bırakılamaz")]
        public string CategoryName { get; set; }
    }
}
