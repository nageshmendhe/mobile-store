using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mobile_store.Models;

public partial class MobilePhoneStoreContext : DbContext
{
    public MobilePhoneStoreContext()
    {
    }

    public MobilePhoneStoreContext(DbContextOptions<MobilePhoneStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSale> ProductSales { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesRecord> SalesRecords { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Volet> Volets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-4ODO15H;Initial Catalog=MobilePhoneStore;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brand__DAD4F05E075F459D");

            entity.ToTable("Brand");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CDE30849A1");

            entity.ToTable("Product");

            entity.HasIndex(e => e.BrandId, "BrandId").IsUnique();

            entity.Property(e => e.ProductDetails)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProductType)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Product_Type");

            entity.HasOne(d => d.Brand).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.BrandId)
                .HasConstraintName("FK_Product_Brand");
        });

        modelBuilder.Entity<ProductSale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductSale");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductSa__Produ__48CFD27E");

            entity.HasOne(d => d.Sale).WithMany()
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__ProductSa__SaleI__47DBAE45");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sale");

            entity.HasOne(d => d.SaleNavigation).WithMany()
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__Sale__SaleId__45F365D3");
        });

        modelBuilder.Entity<SalesRecord>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales_Re__1EE3C3FF26132FF6");

            entity.ToTable("Sales_Records");

            entity.HasOne(d => d.User).WithMany(p => p.SalesRecords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sales_Rec__UserI__440B1D61");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TransactionType)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CAABA6E74");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Volet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Volet__3214EC07CAB59622");

            entity.ToTable("Volet");

            entity.Property(e => e.Card)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Online)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Volets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Volet__UserId__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
