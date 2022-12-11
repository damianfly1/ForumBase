using Domain.Models.Configuration;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Principal;

namespace Persistance;

public class ForumHubDBContext : IdentityDbContext<User>
{
    public DbSet<Forum> Forums  => Set<Forum>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<SubForum> Subforums => Set<SubForum>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       // Debugger.Launch();

        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ForumHubDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       //Debugger.Launch();

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.Entity<LikedPosts>().HasKey(lp => new { lp.UserId, lp.PostId });

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Topic)
            .WithMany(t=>t.Posts)
            .HasForeignKey(p => p.TopicId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubForum>()
            .HasOne(s => s.CreatedBy)
            .WithMany()
            .HasForeignKey(s => s.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
