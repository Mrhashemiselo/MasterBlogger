using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .ToTable("Articles");
            builder
                .HasKey(a => a.Id);
            builder
                .Property(a => a.Title);
            builder
                .Property(a => a.ShortDescription);
            builder
                .Property(a => a.Image);
            builder
                .Property(a => a.Content);
            builder
                .Property(a => a.CreationDate);
            builder
                .Property(a => a.IsDeleted);
            builder
                .HasOne(a => a.ArticleCategory)
                .WithMany(m => m.Articles)
                .HasForeignKey(f => f.ArticleCategoryId);
            
            builder
                .HasMany(a => a.Comments)
                .WithOne(s => s.Article)
                .HasForeignKey(d => d.ArticleId);
        }
    }
}
