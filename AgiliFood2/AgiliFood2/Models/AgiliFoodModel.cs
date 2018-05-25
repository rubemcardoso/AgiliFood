namespace AgiliFood2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AgiliFoodModel : DbContext
    {
        public AgiliFoodModel()
            : base("name=AgiliFoodModel")
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Financial> Financial { get; set; }
        public virtual DbSet<MenusGroup> MenusGroup { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Menus>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Menus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Price)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Products)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Suppliers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Financial>()
                .Property(e => e.Employee)
                .IsUnicode(false);

            modelBuilder.Entity<Financial>()
                .Property(e => e.Product)
                .IsUnicode(false);

            modelBuilder.Entity<Financial>()
                .Property(e => e.Unit_Price)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Financial>()
                .Property(e => e.Total_Product)
                .HasPrecision(30, 2);

            modelBuilder.Entity<MenusGroup>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<MenusGroup>()
                .Property(e => e.ProductPrice)
                .HasPrecision(19, 2);

            modelBuilder.Entity<MenusGroup>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

        }
    }
}
