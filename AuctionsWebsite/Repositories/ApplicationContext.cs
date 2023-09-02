using Entities.DAO.Auction;
using Entities.DAO.Auth;
using Entities.DAO.Product;
using Entities.DAO.Wallet;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    /// <summary>
    /// Application context
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// User table
        /// </summary>
        public virtual DbSet<RegisterDAO> Users { get; set; }

        /// <summary>
        /// Auction table
        /// </summary>
        public virtual DbSet<AuctionDAO> Auctions { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        /// <summary>
        /// Handles properties of the tables that will be created by the migrations
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RegisterDAO>(entity =>
            {
                entity.ToTable("User");
            });

            builder.Entity<WalletDAO>(entity =>
            {
                entity.ToTable("Wallet");
            });

            builder.Entity<ProductDAO>(entity =>
            {
                entity.ToTable("Product").HasData(
                    new ProductDAO { Id = 1, ProductName = "Artist's hat", ProductDescription = "It's an artists hat!" },
                    new ProductDAO { Id = 2, ProductName = "Tim's soul", ProductDescription = "It's Tim's soul! JK :)" },
                    new ProductDAO { Id = 3, ProductName = "My soul", ProductDescription = "I don't know whose this is but it ain't mine!" });
            });

            builder.Entity<AuctionDAO>(entity =>
            {
                entity.ToTable("Auction");
            });

            base.OnModelCreating(builder);
        }
    }
}