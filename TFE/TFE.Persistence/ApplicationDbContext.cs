using Microsoft.EntityFrameworkCore;
using TFE.Domain.Abstractions;
using TFE.Domain.Entities;

namespace TFE.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Test> Tests => Set<Test>();

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
