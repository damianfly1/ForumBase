using Domain.Models.Entities;
using System.Data.Entity;

namespace Persistance;

public class ForumHubDBContext : DbContext
{
    public ForumHubDBContext() : base("ForumHubDB")
    {
    }

    public DbSet<Forum> Forums  => Set<Forum>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Subforum> Subforums => Set<Subforum>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<Image> Images => Set<Image>();

}
