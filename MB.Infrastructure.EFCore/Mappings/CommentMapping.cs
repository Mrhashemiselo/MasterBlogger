using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mappings;

public class CommentMapping:IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .ToTable("Comments");
        builder
            .HasKey(a => a.Id);
        builder
            .Property(q => q.Name);
        builder
            .Property(q => q.Email);
        builder
            .Property(q => q.Message);
        builder
            .Property(q => q.CreationDate);
        builder
            .Property(q => q.Status);
        builder
            .HasOne(a => a.Article)
            .WithMany(s => s.Comments)
            .HasForeignKey(d => d.ArticleId);
    }
}