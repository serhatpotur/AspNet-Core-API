using AspNetCoreProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { ProductID = 1, ProductName = "Mavi Pilot Kalem", ProductPrice = 12.50m, ProductStock = 100, CategoryID = _ids[0] },
                 new Product { ProductID = 2, ProductName = "Kurşun Kalem", ProductPrice = 40.50m, ProductStock = 200, CategoryID = _ids[0] },
                 new Product { ProductID = 3, ProductName = "Siyah Tükenmez Kalem", ProductPrice = 500m, ProductStock = 300, CategoryID = _ids[0] },
                 new Product { ProductID = 4, ProductName = "60 Yaprak Küçük Boy Defter", ProductPrice = 12.50m, ProductStock = 100, CategoryID = _ids[1] },
                 new Product { ProductID = 5, ProductName = "120 Yaprak Orta Boy Defter", ProductPrice = 18.50m, ProductStock = 100, CategoryID = _ids[1] },
                 new Product { ProductID = 6, ProductName = "180 Yaprak Büyük Boy Defter", ProductPrice = 14.50m, ProductStock = 100, CategoryID = _ids[1] }
        );
        }
    }
}
