﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240611084755_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.backpacks", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("backpacks");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1,
                            Amount = 2
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 2,
                            Amount = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 3,
                            Amount = 3
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.character_titles", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CharacterId", "TitleId");

                    b.HasIndex("TitleId");

                    b.ToTable("character_titles");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            TitleId = 1,
                            AcquiredAt = new DateTime(2024, 6, 11, 10, 47, 55, 616, DateTimeKind.Local).AddTicks(1283)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 2,
                            AcquiredAt = new DateTime(2024, 6, 12, 10, 47, 55, 616, DateTimeKind.Local).AddTicks(1328)
                        },
                        new
                        {
                            CharacterId = 1,
                            TitleId = 3,
                            AcquiredAt = new DateTime(2024, 6, 13, 10, 47, 55, 616, DateTimeKind.Local).AddTicks(1332)
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.characters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWei")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentWei = 43,
                            FirstName = "John",
                            LastName = "Yakuza",
                            MaxWeight = 200
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Item1",
                            Weight = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Item2",
                            Weight = 11
                        },
                        new
                        {
                            Id = 3,
                            Name = "Item3",
                            Weight = 12
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.titles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("titles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Title1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Title3"
                        });
                });

            modelBuilder.Entity("WebApplication2.Models.backpacks", b =>
                {
                    b.HasOne("WebApplication2.Models.characters", "Character")
                        .WithMany("BackpacksCollection")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.items", "Item")
                        .WithMany("BackpacksCollection")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WebApplication2.Models.character_titles", b =>
                {
                    b.HasOne("WebApplication2.Models.characters", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.titles", "Title")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("WebApplication2.Models.characters", b =>
                {
                    b.Navigation("BackpacksCollection");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("WebApplication2.Models.items", b =>
                {
                    b.Navigation("BackpacksCollection");
                });

            modelBuilder.Entity("WebApplication2.Models.titles", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}