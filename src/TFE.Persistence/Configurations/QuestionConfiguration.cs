using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFE.Domain.Testing.TestAgregate;

namespace TFE.Infrastructure.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id);

        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(90).IsRequired();
        builder.Property(x => x.Body).HasMaxLength(512).IsRequired();
        
        builder.HasOne(x => x.Test)
            .WithMany(x => x.Questions)
            .HasForeignKey(x => x.TestId)
            .IsRequired();

    }
}