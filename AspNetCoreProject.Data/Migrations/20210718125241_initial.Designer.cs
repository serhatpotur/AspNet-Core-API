// <auto-generated />
using AspNetCoreProject.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreProject.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210718125241_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreProject.Core.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Kalemler",
                            isDeleted = false
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Defterler",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("AspNetCoreProject.Core.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductStock")
                        .HasColumnType("int");

                    b.Property<string>("innerBarcode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            ProductName = "Mavi Pilot Kalem",
                            ProductPrice = 12.50m,
                            ProductStock = 100,
                            isDeleted = false
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            ProductName = "Kurşun Kalem",
                            ProductPrice = 40.50m,
                            ProductStock = 200,
                            isDeleted = false
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 1,
                            ProductName = "Siyah Tükenmez Kalem",
                            ProductPrice = 500m,
                            ProductStock = 300,
                            isDeleted = false
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 2,
                            ProductName = "60 Yaprak Küçük Boy Defter",
                            ProductPrice = 12.50m,
                            ProductStock = 100,
                            isDeleted = false
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 2,
                            ProductName = "120 Yaprak Orta Boy Defter",
                            ProductPrice = 18.50m,
                            ProductStock = 100,
                            isDeleted = false
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 2,
                            ProductName = "180 Yaprak Büyük Boy Defter",
                            ProductPrice = 14.50m,
                            ProductStock = 100,
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("AspNetCoreProject.Core.Entities.Product", b =>
                {
                    b.HasOne("AspNetCoreProject.Core.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AspNetCoreProject.Core.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
