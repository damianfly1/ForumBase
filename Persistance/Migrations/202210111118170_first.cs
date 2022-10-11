namespace Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsModerationOnly = c.Boolean(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Forum_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Fora", t => t.Forum_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Forum_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        NickName = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsBanned = c.Boolean(nullable: false),
                        Reputation = c.Int(nullable: false),
                        Footer = c.String(),
                        Role = c.Int(nullable: false),
                        Avatar_Id = c.Guid(),
                        Forum_Id = c.Guid(),
                        Category_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Avatar_Id)
                .ForeignKey("dbo.Fora", t => t.Forum_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Avatar_Id)
                .Index(t => t.Forum_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        Data = c.Binary(),
                        CreatedBy_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        Status = c.Int(nullable: false),
                        Author_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                        Recipent_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .ForeignKey("dbo.Users", t => t.Recipent_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id)
                .Index(t => t.Recipent_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Fora",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Faq = c.String(),
                        Rules = c.String(),
                        CreatedBy_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id);
            
            CreateTable(
                "dbo.Subforums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Category_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .ForeignKey("dbo.Subforums", t => t.Parent_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        Name = c.String(),
                        IsPinned = c.Boolean(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        Author_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                        Subforum_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .ForeignKey("dbo.Subforums", t => t.Subforum_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id)
                .Index(t => t.Subforum_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdatedAt = c.DateTime(nullable: false),
                        Text = c.String(),
                        Rating = c.Int(nullable: false),
                        IsEdited = c.Boolean(nullable: false),
                        Author_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                        LastUpdatedBy_Id = c.Guid(),
                        Topic_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id)
                .Index(t => t.Topic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Subforum_Id", "dbo.Subforums");
            DropForeignKey("dbo.Posts", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Posts", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Topics", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Topics", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Topics", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Subforums", "Parent_Id", "dbo.Subforums");
            DropForeignKey("dbo.Subforums", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Subforums", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Subforums", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Users", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Fora", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Fora", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Categories", "Forum_Id", "dbo.Fora");
            DropForeignKey("dbo.Users", "Forum_Id", "dbo.Fora");
            DropForeignKey("dbo.Categories", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Recipent_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Avatar_Id", "dbo.Images");
            DropForeignKey("dbo.Images", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Images", "CreatedBy_Id", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "Topic_Id" });
            DropIndex("dbo.Posts", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Posts", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropIndex("dbo.Topics", new[] { "Subforum_Id" });
            DropIndex("dbo.Topics", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Topics", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Topics", new[] { "Author_Id" });
            DropIndex("dbo.Subforums", new[] { "Parent_Id" });
            DropIndex("dbo.Subforums", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Subforums", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Subforums", new[] { "Category_Id" });
            DropIndex("dbo.Fora", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Fora", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "Recipent_Id" });
            DropIndex("dbo.Messages", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Messages", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Messages", new[] { "Author_Id" });
            DropIndex("dbo.Images", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Images", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Users", new[] { "Category_Id" });
            DropIndex("dbo.Users", new[] { "Forum_Id" });
            DropIndex("dbo.Users", new[] { "Avatar_Id" });
            DropIndex("dbo.Categories", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.Categories", new[] { "Forum_Id" });
            DropIndex("dbo.Categories", new[] { "CreatedBy_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Topics");
            DropTable("dbo.Subforums");
            DropTable("dbo.Fora");
            DropTable("dbo.Messages");
            DropTable("dbo.Images");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
