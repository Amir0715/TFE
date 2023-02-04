using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFE.Domain.Testing.AuthorAgregate;

namespace TFE.Infrastructure.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(48).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(48).IsRequired();
        builder.Property(x => x.Patronymic).HasMaxLength(48);

        //builder.Metadata.FindNavigation(nameof(UserProfile.Tests))
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}