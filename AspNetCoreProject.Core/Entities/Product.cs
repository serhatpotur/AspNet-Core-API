using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreProject.Core.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryID { get; set; }
        public bool isDeleted { get; set; }
        public string innerBarcode { get; set; }

        public virtual Category Category { get; set; }
    }
}
