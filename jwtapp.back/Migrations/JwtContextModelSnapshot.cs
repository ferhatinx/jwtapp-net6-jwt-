// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jwtapp.back.Persistance.Context;

#nullable disable

namespace jwtapp.back.Migrations
{
    [DbContext(typeof(JwtContext))]
    partial class JwtContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("jwtapp.back.Core.Domain.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Definition")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Definition = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Definition = "Member"
                        });
                });

            modelBuilder.Entity("jwtapp.back.Core.Domain.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppRoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppRoleId");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppRoleId = 1,
                            Password = "1",
                            Username = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            AppRoleId = 2,
                            Password = "1",
                            Username = "Member"
                        });
                });

            modelBuilder.Entity("jwtapp.back.Core.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Definition")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Definition = "Giyim"
                        },
                        new
                        {
                            Id = 2,
                            Definition = "Elektronik"
                        });
                });

            modelBuilder.Entity("jwtapp.back.Core.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Elbise",
                            Price = 40m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Name = "Buzdolabı",
                            Price = 40m,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("jwtapp.back.Core.Domain.AppUser", b =>
                {
                    b.HasOne("jwtapp.back.Core.Domain.AppRole", "AppRole")
                        .WithMany("AppUsers")
                        .HasForeignKey("AppRoleId");

                    b.Navigation("AppRole");
                });

            modelBuilder.Entity("jwtapp.back.Core.Domain.Product", b =>
                {
                    b.HasOne("jwtapp.back.Core.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("jwtapp.back.Core.Domain.AppRole", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("jwtapp.back.Core.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
