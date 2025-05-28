using AutoPartsSite.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AutoPartsSite.Repository.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<BlogCategory?> BlogCategories { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<CollaborationRequest> CollaborationRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // پیکربندی رابطه یک-به-چند بین Category و BlogPost
        builder.Entity<BlogPost>()
            .HasOne(bp => bp.Category)
            .WithMany(c => c.BlogPosts)
            .HasForeignKey(bp => bp.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // پیکربندی رابطه خودارجاعی برای Category (Parent-Child)
        builder.Entity<BlogCategory>()
            .HasOne(c => c.ParentCategory)
            .WithMany(c => c.ChildCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.SetNull);

    }
}
