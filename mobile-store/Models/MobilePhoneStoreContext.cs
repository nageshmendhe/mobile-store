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

    public virtual DbSet<Brand> Brand { get; set; }

    public virtual DbSet<Deals> Deals { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Products> Product { get; set; }

    public virtual DbSet<Transactions> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<OrderProductId> OrderProductId { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-4ODO15H;Initial Catalog=MobilePhoneStore;Integrated Security=True;Trust Server Certificate=True;");

    
}
