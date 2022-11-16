using Domain.Models.Configuration;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Persistance;

public class ForumHubDBContext : IdentityDbContext<User>
{
    public DbSet<Forum> Forums  => Set<Forum>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<SubForum> Subforums => Set<SubForum>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Image> Images => Set<Image>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ForumHubDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.Entity<Category>()
            .HasOne(c => c.CreatedBy)
            .WithMany()
            .HasForeignKey(c => c.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
            .HasOne(c => c.LastUpdatedBy)
            .WithMany()
            .HasForeignKey(c => c.LastUpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Forum>()
            .HasOne(f => f.CreatedBy)
            .WithMany()
            .HasForeignKey(f => f.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Forum>()
            .HasOne(f => f.LastUpdatedBy)
            .WithMany()
            .HasForeignKey(f => f.LastUpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Post>()
        //    .HasOne(p => p.CreatedBy)
        //    .WithMany()
        //    .HasForeignKey(p => p.CreatedById)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.LastUpdatedBy)
            .WithMany()
            .HasForeignKey(p => p.LastUpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

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

        modelBuilder.Entity<SubForum>()
            .HasOne(s => s.LastUpdatedBy)
            .WithMany()
            .HasForeignKey(s => s.LastUpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Topic>()
        //    .HasOne(t => t.CreatedBy)
        //    .WithMany()
        //    .HasForeignKey(t => t.CreatedById)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Topic>()
            .HasOne(t => t.LastUpdatedBy)
            .WithMany()
            .HasForeignKey(t => t.LastUpdatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Image>()
            .HasOne(i => i.CreatedBy)
            .WithOne()
            .HasForeignKey<Image>(i => i.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(i => i.Avatar)
            .WithOne()
            .HasForeignKey<User>(i => i.AvatarId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
