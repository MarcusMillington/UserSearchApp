using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    /// <summary>
    /// Represents the Entity Framework database context for user search operations.
    /// </summary>
    public class UserSearchDbContext : DbContext
    {
        public UserSearchDbContext(DbContextOptions<UserSearchDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// The Users table.
        /// </summary>
        public DbSet<User> User { get; set; }

        public List<User> GetUsers()
        {
            return User.ToList();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserSearchDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
