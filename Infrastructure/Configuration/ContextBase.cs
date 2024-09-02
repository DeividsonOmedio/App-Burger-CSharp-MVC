using Domain.Entities.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Configuration
{
    public partial class ContextBase : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura chaves compostas
            modelBuilder.Entity<SaleProduct>()
                .HasKey(sp => new { sp.SaleId, sp.ProductId });

            modelBuilder.Entity<SaleProduct>()
                .HasOne(sp => sp.Sale)
                .WithMany()
                .HasForeignKey(sp => sp.SaleId);

            modelBuilder.Entity<SaleProduct>()
                .HasOne(sp => sp.Product)
                .WithMany()
                .HasForeignKey(sp => sp.ProductId);

            // Seed data para Clients
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Client 1", Email = "client1@example.com", PhoneNumber = "12345678901", DataBirth = new DateOnly(1990, 1, 1), RegisteredIn = DateTime.Now },
                new Client { Id = 2, Name = "Client 2", Email = "client2@example.com", PhoneNumber = "09876543210", DataBirth = new DateOnly(1985, 5, 10), RegisteredIn = DateTime.Now }
            );

            // Seed data para Materials
            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Name = "Bife Bovino", Amount = 100, MinimumQuantity = 20, PurchasePrice = 1.50m },
                new Material { Id = 2, Name = "Pao de Hamburguer", Amount = 100, MinimumQuantity = 20, PurchasePrice = 1.00m },
                new Material { Id = 3, Name = "Bacon", Amount = 2000, MinimumQuantity = 200, PurchasePrice = 1.00m },
                new Material { Id = 4, Name = "Cheddar", Amount = 2000, MinimumQuantity = 200, PurchasePrice = 1.00m },
                new Material { Id = 5, Name = "Ovo", Amount = 2000, MinimumQuantity = 200, PurchasePrice = 0.50m }

            );

            // Seed data para Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "X-Tudo", Code = Guid.NewGuid(), Amount = 10, Price = 20 },
                new Product { Id = 2, Name = "X-Egg-Bacon", Code = Guid.NewGuid(), Amount = 15, Price = 18 }
            );

            // Seed data para Ingredients
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { Id = 1, ProductId = 1, MaterialId = 1, Amount = 2 },
                new Ingredients { Id = 2, ProductId = 1, MaterialId = 2, Amount = 1 },
                new Ingredients { Id = 3, ProductId = 1, MaterialId = 3, Amount = 0.200m },
                new Ingredients { Id = 4, ProductId = 1, MaterialId = 4, Amount = 1 },
                new Ingredients { Id = 5, ProductId = 1, MaterialId = 5, Amount = 2 },
                new Ingredients { Id = 6, ProductId = 2, MaterialId = 1, Amount = 1 },
                new Ingredients { Id = 7, ProductId = 2, MaterialId = 2, Amount = 1 },
                new Ingredients { Id = 8, ProductId = 2, MaterialId = 3, Amount = 0.300m }
                                                                                       );

            // Seed data para Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Employee 1", User = "Admin", Function = EnumFunctionEmployee.administrator, Password = "Dev@123" },
                new Employee { Id = 2, Name = "Employee 2", User = "Dev", Function = EnumFunctionEmployee.general, Password = "Dev@123" }
            );

            // Seed data para Sales
            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    Id = 1,
                    SaleDate = DateTime.Now,
                    ClientId = 1,
                    TotalValue = 400,
                    TypePayment = EnumTypePayment.credit,
                    StatusSale = EnumStatusSale.delivered,
                    StatusPayment = EnumStatusPayment.paid,
                    Discount = 0,
                    EmployeeId = 1
                },
                new Sale
                {
                    Id = 2,
                    SaleDate = DateTime.Now,
                    ClientId = 2,
                    TotalValue = 600,
                    TypePayment = EnumTypePayment.pix,
                    StatusSale = EnumStatusSale.pendent,
                    StatusPayment = EnumStatusPayment.pendent,
                    Discount = 50,
                    EmployeeId = 2
                }
            );

            // Seed data para SaleProduct (Relacionamento)
            modelBuilder.Entity<SaleProduct>().HasData(
                new SaleProduct { Id = 1, SaleId = 1, ProductId = 1, Amount = 2 },
                new SaleProduct { Id = 2, SaleId = 1, ProductId = 2, Amount = 1 },
                new SaleProduct { Id = 3, SaleId = 2, ProductId = 1, Amount = 1 },
                new SaleProduct { Id = 4, SaleId = 2, ProductId = 2, Amount = 2 }
            );
        }
    }
}
