using Microsoft.EntityFrameworkCore;
using ProjectFiado.Domain.Models;
using ProjectFiado.Models;

namespace ProjectFiado.Data
{
    public class FiadoDBContext:DbContext
    {
        public FiadoDBContext(DbContextOptions<FiadoDBContext> options) : base(options) { }
        
        public DbSet<ProductModel> products { get; set; }
        public DbSet<StockModel> stocks { get; set; }
        public DbSet<UserModel> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StockModel>()
                          .HasOne(stock => stock.Product) // Referência ao objeto ProductModel
                          .WithMany() // Se você tiver uma coleção de StockModel em ProductModel, pode usar .WithMany(product => product.Stocks)
                          .HasForeignKey(stock => stock.ProductID);
        }

    }
}
