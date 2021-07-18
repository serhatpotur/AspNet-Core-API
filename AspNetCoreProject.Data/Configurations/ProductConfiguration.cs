using AspNetCoreProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreProject.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductID); //PK yap
            builder.Property(x => x.ProductID).UseIdentityColumn(); //identity artsın
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ProductStock).IsRequired();
            builder.Property(x => x.ProductPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.innerBarcode).HasMaxLength(50);
            builder.ToTable("Products");

        }
    }
}
