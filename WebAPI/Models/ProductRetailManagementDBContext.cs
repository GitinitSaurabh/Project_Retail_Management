using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Models
{
    public partial class ProductRetailManagementDBContext : DbContext
    {
        //public ProductRetailManagementDBContext()
        //{
        //}

        public ProductRetailManagementDBContext(DbContextOptions<ProductRetailManagementDBContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<VendorStocks> VendorStocks { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }
        public virtual DbSet<WishLists> WishLists { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");



            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => e.CartId);



                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");



                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carts_Products");



                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Carts_Vendors");
            });



            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(500);
                entity.Property(e => e.FirstName).HasMaxLength(500);
                entity.Property(e => e.LastName).HasMaxLength(0);
                entity.Property(e => e.Password).HasMaxLength(50);
            });



            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(4000);
                entity.Property(e => e.ImageName).HasMaxLength(500);
                entity.Property(e => e.Name).HasMaxLength(500);
            });



            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);
            });



            modelBuilder.Entity<VendorStocks>(entity =>
            {
                entity.HasKey(e => e.StockId);



                entity.Property(e => e.ExpectedDate).HasColumnType("datetime");



                entity.HasOne(d => d.Product)
                    .WithMany(p => p.VendorStocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_VendorStocks_Products");



                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorStocks)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_VendorStocks_Vendors");
            });



            modelBuilder.Entity<WishLists>(entity =>
            {
                entity.HasKey(e => e.WishlistId);



                entity.Property(e => e.DateAdded).HasColumnType("datetime");



                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_WishLists_Customers");



                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_WishLists_Products");



                entity.HasOne(d => d.Vendor)
                    .WithMany()
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_WishLists_Vendors");
            });



            //OnModelCreatingPartial(modelBuilder);
        }


    }
}
