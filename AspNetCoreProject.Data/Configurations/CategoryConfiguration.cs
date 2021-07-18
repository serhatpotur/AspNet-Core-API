using AspNetCoreProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreProject.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryID); //PK yap
            builder.Property(x => x.CategoryID).UseIdentityColumn(); //identity artsın
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
        }
    }
}
