using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AspNetCoreProject.Core.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>(); 
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
