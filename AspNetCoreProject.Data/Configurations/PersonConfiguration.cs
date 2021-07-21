using AspNetCoreProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreProject.Data.Configurations
{
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.PersonID);
            builder.Property(x => x.PersonID).UseIdentityColumn();
            builder.Property(x => x.PersonName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.PersonSurname).IsRequired().HasMaxLength(20);
            builder.ToTable("Persons");
        }
    }
}
