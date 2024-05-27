using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore
{
    public class MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) : DbContext(options)
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
