using Entities.DAO.Auth;
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

            base.OnModelCreating(builder);
        }
    }
}