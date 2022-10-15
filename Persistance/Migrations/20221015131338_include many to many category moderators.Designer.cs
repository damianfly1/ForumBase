﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(ForumHubDBContext))]
    [Migration("20221015131338_include many to many category moderators")]
    partial class includemanytomanycategorymoderators
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsModerationOnly")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ForumId");

                    b.HasIndex("LastUpdatedById");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Models.Entities.CategoryModerator", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryModerator");
                });

            modelBuilder.Entity("Domain.Models.Entities.Forum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faq")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rules")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("Domain.Models.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById")
                        .IsUnique();

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.Models.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("TopicId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Models.Entities.Subforum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("ParentId");

                    b.ToTable("Subforums");
                });

            modelBuilder.Entity("Domain.Models.Entities.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubforumId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastUpdatedById");

                    b.HasIndex("SubforumId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Domain.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AvatarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Footer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reputation")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId")
                        .IsUnique()
                        .HasFilter("[AvatarId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Entities.Category", b =>
                {
                    b.HasOne("Domain.Models.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Forum", "Forum")
                        .WithMany("Categories")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Forum");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Domain.Models.Entities.CategoryModerator", b =>
                {
                    b.HasOne("Domain.Models.Entities.Category", "Category")
                        .WithMany("CategoryModerators")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "User")
                        .WithMany("CategoryModerators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Entities.Forum", b =>
                {
                    b.HasOne("Domain.Models.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", null)
                        .WithMany("Admins")
                        .HasForeignKey("UserId");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Domain.Models.Entities.Image", b =>
                {
                    b.HasOne("Domain.Models.Entities.User", "CreatedBy")
                        .WithOne()
                        .HasForeignKey("Domain.Models.Entities.Image", "CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Domain.Models.Entities.Post", b =>
                {
                    b.HasOne("Domain.Models.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Topic", null)
                        .WithMany("Posts")
                        .HasForeignKey("TopicId");

                    b.Navigation("Author");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Domain.Models.Entities.Subforum", b =>
                {
                    b.HasOne("Domain.Models.Entities.Category", "Category")
                        .WithMany("Subforums")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Domain.Models.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Subforum", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Domain.Models.Entities.Topic", b =>
                {
                    b.HasOne("Domain.Models.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.User", "LastUpdatedBy")
                        .WithMany()
                        .HasForeignKey("LastUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Entities.Subforum", null)
                        .WithMany("Topics")
                        .HasForeignKey("SubforumId");

                    b.Navigation("Author");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastUpdatedBy");
                });

            modelBuilder.Entity("Domain.Models.Entities.User", b =>
                {
                    b.HasOne("Domain.Models.Entities.Image", "Avatar")
                        .WithOne()
                        .HasForeignKey("Domain.Models.Entities.User", "AvatarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("Domain.Models.Entities.Category", b =>
                {
                    b.Navigation("CategoryModerators");

                    b.Navigation("Subforums");
                });

            modelBuilder.Entity("Domain.Models.Entities.Forum", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Domain.Models.Entities.Subforum", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Domain.Models.Entities.Topic", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Domain.Models.Entities.User", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("CategoryModerators");
                });
#pragma warning restore 612, 618
        }
    }
}