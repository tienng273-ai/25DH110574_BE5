using System.Data.Entity;

namespace BE5_CustomerSite.Models
{
    public class MyStoreEntities : DbContext
    {
        public MyStoreEntities() : base("name=MyStoreEntities") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(x => x.Username);
            modelBuilder.Entity<User>().Property(x => x.Username).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(x => x.UserRole).IsRequired().HasMaxLength(1);

            modelBuilder.Entity<Customer>().ToTable("Customer").HasKey(x => x.CustomerID);
            modelBuilder.Entity<Customer>().Property(x => x.CustomerName).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.CustomerPhone).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Customer>().Property(x => x.Username).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Customer>().HasRequired(x => x.User)
                .WithMany().HasForeignKey(x => x.Username);

            modelBuilder.Entity<Category>().ToTable("Category").HasKey(x => x.CategoryID);
            modelBuilder.Entity<Product>().ToTable("Product").HasKey(x => x.ProductID);
            modelBuilder.Entity<Product>().Property(x => x.ProductPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().HasRequired(x => x.Category)
                .WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);

            modelBuilder.Entity<Order>().ToTable("Order").HasKey(x => x.OrderID);
            modelBuilder.Entity<Order>().Property(x => x.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().HasRequired(x => x.Customer)
                .WithMany(x => x.Orders).HasForeignKey(x => x.CustomerID);

            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail").HasKey(x => x.ID);
            modelBuilder.Entity<OrderDetail>().Property(x => x.UnitPrice).HasPrecision(18, 2);
            modelBuilder.Entity<OrderDetail>().HasRequired(x => x.Product)
                .WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<OrderDetail>().HasRequired(x => x.Order)
                .WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
