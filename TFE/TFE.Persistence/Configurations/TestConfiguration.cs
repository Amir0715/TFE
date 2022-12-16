using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFE.Domain.Entities;

namespace TFE.Persistence.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Category).WithMany();
        builder.HasMany(x => x.Questions).WithOne(x => x.Test);

        builder.Property(x => x.Title).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        builder.Property(b => b.Questions).HasField("_questions");
        // Маппим навигационное поле, что бы ef core проставляло вопросы в приватное поле
        builder.Metadata.FindNavigation(nameof(Test.Questions))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}