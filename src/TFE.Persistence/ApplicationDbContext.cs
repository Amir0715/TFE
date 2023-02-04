using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFE.Domain.Abstractions;
using TFE.Domain.Testing.AuthorAgregate;
using TFE.Domain.Testing.TestAgregate;
using TFE.Infrastructure.Identity;

namespace TFE.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>, IUnitOfWork
    {
        public DbSet<Test> Tests => Set<Test>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Author> UserProfiles => Set<Author>();

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
