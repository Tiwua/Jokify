﻿// <auto-generated />
using System;
using Jokify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jokify.Infrastructure.Migrations
{
    [DbContext(typeof(JokifyDbContext))]
    [Migration("20230704203236_JokesDataSeeded")]
    partial class JokesDataSeeded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.JokeEntities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Delete flag that shows if the comment has been deleted");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit")
                        .HasComment("Edit flag that shows if the comment has been edited");

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit")
                        .HasComment("Popular flag that shows if the comment is popular");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasComment("Joke comment");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.JokeEntities.Joke", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary Key");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Delete flag that shows if the joke has been deleted");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit")
                        .HasComment("Edit flag that shows if the joke has been edited");

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit")
                        .HasComment("Popular flag that shows if the joke is popular");

                    b.Property<int>("JokeCategoryId")
                        .HasColumnType("int")
                        .HasComment("Foreign Key referencing JokeCategory");

                    b.Property<string>("Punchline")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Funniest part of the joke");

                    b.Property<string>("Setup")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Introduction part of the joke");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Title of the joke");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Foreign Key referencing User");

                    b.HasKey("Id");

                    b.HasIndex("JokeCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Jokes");

                    b.HasComment("Joke for the WebApp");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bdb63ebd-57c9-4c43-b628-a24ae6a165a0"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 1,
                            Punchline = "Do these genes make me look fat?",
                            Setup = "What did the Dna say to the other DNA?",
                            Title = "Fat DNA?",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        },
                        new
                        {
                            Id = new Guid("8ebbe6a9-5aa9-4115-b73b-beae168bfea3"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 2,
                            Punchline = "Because its two - tired.",
                            Setup = "A bicycle can't stand on its own",
                            Title = "Bicycle",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        },
                        new
                        {
                            Id = new Guid("3ddead2d-3713-40cb-973d-5b45cc64bceb"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 3,
                            Punchline = "Who. \r\n Who who? \r\n What are you, an owl?",
                            Setup = "Knock, knock.\r\n Who’s there?",
                            Title = "Owl",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        },
                        new
                        {
                            Id = new Guid("3eab60b5-16fa-4a92-8178-4faa7eff5187"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 4,
                            Punchline = "So if anyone asks, I’m outstanding.",
                            Setup = "I'm going to stand outside.",
                            Title = "Outside",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        },
                        new
                        {
                            Id = new Guid("87484f13-f1f9-4c49-a117-a73280b786ec"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 5,
                            Punchline = "A Carrot.",
                            Setup = "What is orange and sounds like a parrot?",
                            Title = "Parrot",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        },
                        new
                        {
                            Id = new Guid("bf36a12e-18e2-43d5-8ec8-10187ff4eae2"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 6,
                            Punchline = "Because they make up everything!",
                            Setup = "Why don't scientists trust atoms?",
                            Title = "Trust Issues",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        },
                        new
                        {
                            Id = new Guid("5eafbc21-db10-4ce0-ae9b-59d090a0571a"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 7,
                            Punchline = "The Space Bar!",
                            Setup = "What’s an astronaut’s favorite part of a computer?",
                            Title = "Favorite PC Part",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        },
                        new
                        {
                            Id = new Guid("f3fdad70-1862-4f6f-943e-7fc0315b67f5"),
                            IsDeleted = false,
                            IsEdited = false,
                            IsPopular = false,
                            JokeCategoryId = 8,
                            Punchline = "They don't have the guts!",
                            Setup = "Why don't skeletons fight each other?",
                            Title = "Skeletons",
                            UserId = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c"
                        });
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.JokeEntities.JokeComment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key refering comment of the joke");

                    b.Property<Guid>("JokeId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key refering the joke");

                    b.HasKey("CommentId", "JokeId");

                    b.HasIndex("JokeId");

                    b.ToTable("JokesComments");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.MappingTables.JokeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("JokeCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "One-Liner"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pun"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Knock-knock"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Wordplay"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Riddle"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Observational"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Dad joke"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Dark humor"
                        });
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.MappingTables.UserFavoriteJoke", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Primary key refering user's favorite joke");

                    b.Property<Guid>("JokeId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key refering the joke");

                    b.HasKey("UserId", "JokeId");

                    b.HasIndex("JokeId");

                    b.ToTable("UsersFavoritesJokes");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.MappingTables.UserJoke", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Primary key refering user's created joke");

                    b.Property<Guid>("JokeId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key refering the joke");

                    b.HasKey("UserId", "JokeId");

                    b.HasIndex("JokeId");

                    b.ToTable("UsersJokes");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cfbab976-a6d3-44c2-bdce-51c3b6b0412c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c8a7e76f-648a-4891-ba78-938aa55305ef",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAENRPZL31HMo2sDOEwSXYhDsRNayeLkg2P/y5cHKQEckS2Wxhurmri828Wj4c+oaqoQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "756a239f-35a1-4b7e-9c81-98ab4338c2ce",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "ae64ca1c-5403-4f2f-a25d-0a1249145ad3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ae621c5e-e3f2-4026-9d36-7c678b707a44",
                            Email = "someone@gmail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SOMEONE@GMAIL.COM",
                            NormalizedUserName = "SOMEONE",
                            PasswordHash = "AQAAAAEAACcQAAAAEM77YRPb7Qsks+abgqnr0UyYUjGg8zD9IAu1pOvwuHy2ecms6P75ODyzQ9vd+o8iVQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1ab9752a-c6d4-4dbf-8c52-3736621d265b",
                            TwoFactorEnabled = false,
                            UserName = "someone"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.JokeEntities.Joke", b =>
                {
                    b.HasOne("Jokify.Infrastructure.Data.Models.MappingTables.JokeCategory", "Category")
                        .WithMany()
                        .HasForeignKey("JokeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jokify.Infrastructure.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.JokeEntities.JokeComment", b =>
                {
                    b.HasOne("Jokify.Infrastructure.Data.Models.JokeEntities.Comment", "Comment")
                        .WithMany("JokeComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jokify.Infrastructure.Data.Models.JokeEntities.Joke", "Joke")
                        .WithMany("JokeComments")
                        .HasForeignKey("JokeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Joke");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.MappingTables.UserFavoriteJoke", b =>
                {
                    b.HasOne("Jokify.Infrastructure.Data.Models.JokeEntities.Joke", "Joke")
                        .WithMany("FavoriteJokes")
                        .HasForeignKey("JokeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jokify.Infrastructure.Data.Models.User", "User")
                        .WithMany("FavoriteJokes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Joke");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.MappingTables.UserJoke", b =>
                {
                    b.HasOne("Jokify.Infrastructure.Data.Models.JokeEntities.Joke", "Joke")
                        .WithMany()
                        .HasForeignKey("JokeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jokify.Infrastructure.Data.Models.User", "User")
                        .WithMany("CreatedJokes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Joke");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Jokify.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Jokify.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jokify.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Jokify.Infrastructure.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.JokeEntities.Comment", b =>
                {
                    b.Navigation("JokeComments");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.JokeEntities.Joke", b =>
                {
                    b.Navigation("FavoriteJokes");

                    b.Navigation("JokeComments");
                });

            modelBuilder.Entity("Jokify.Infrastructure.Data.Models.User", b =>
                {
                    b.Navigation("CreatedJokes");

                    b.Navigation("FavoriteJokes");
                });
#pragma warning restore 612, 618
        }
    }
}
