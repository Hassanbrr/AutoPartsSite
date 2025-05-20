using AutoPartsSite.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsSite.Repository.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<CollaborationRequest> CollaborationRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
    }
}
