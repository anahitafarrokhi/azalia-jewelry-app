using AzaliaJwellery.Models;
using Microsoft.EntityFrameworkCore;

namespace AzaliaJwellery.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductJewelleryType>()
                .HasOne(pjt => pjt.Product)
                .WithMany(p => p.ProductJewelleryTypes)
                .HasForeignKey(pjt => pjt.ProductId);

            modelBuilder.Entity<ProductJewelleryType>()
                .HasOne(pjt => pjt.JewelleryType)
                .WithMany(jt => jt.ProductJewelleryTypes)
                .HasForeignKey(pjt => pjt.JewelleryTypeId);
            // Configure the relationship between Product and ProductCategory
            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductCategory); // Navigation property in Product
                                                 // .WithMany(c => c.Products)     // Navigation property in ProductCategory
                                                 //.HasForeignKey(p => p.ProductCategoryId)
                                                 // .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<CustomizationOption> CustomizationOption { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<JewelleryType> JewelleryType { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductJewelleryType> ProductJewelleryType { get; set; }
        
    }

}
