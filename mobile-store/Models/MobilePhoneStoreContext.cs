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
            entity.HasKey(e => e.Id).HasName("PK__Brands__3214EC077063C091");

            entity.Property(e => e.BrandName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07701F9D89");

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

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__BrandI__403A8C7D");
        });

        modelBuilder.Entity<ProductSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductS__3214EC073ABDFF67");

            entity.ToTable("ProductSale");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductSa__Produ__47DBAE45");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC07CB70765D");

            entity.ToTable("Sale");
        });

        modelBuilder.Entity<SalesRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sales_Records");

            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn).HasColumnName("createdOn");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdateOn).HasColumnName("updateOn");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.Sale).WithMany()
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__Sales_Rec__SaleI__44FF419A");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sales_Rec__UserI__440B1D61");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.TransactionType)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC070AC5B6DA");

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
            entity.HasKey(e => e.Id).HasName("PK__Volet__3214EC0767475422");

            entity.ToTable("Volet");

            entity.Property(e => e.Card)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Online)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Volets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Volet__UserId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
