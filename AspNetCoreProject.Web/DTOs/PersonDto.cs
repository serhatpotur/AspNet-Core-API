using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Web.DTOs
{
    public class PersonDto
    {
        public int PersonID { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string PersonSurname { get; set; }
    }
}
