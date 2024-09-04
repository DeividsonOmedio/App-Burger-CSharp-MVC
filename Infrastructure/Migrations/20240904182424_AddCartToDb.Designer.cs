﻿// <auto-generated />
using System;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20240904182424_AddCartToDb")]
    partial class AddCartToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2,
                            ClientId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1,
                            ClientId = 2,
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("RegisteredIn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataBirth = new DateOnly(1990, 1, 1),
                            Email = "client1@example.com",
                            Name = "Client 1",
                            PhoneNumber = "12345678901",
                            RegisteredIn = new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(6835)
                        },
                        new
                        {
                            Id = 2,
                            DataBirth = new DateOnly(1985, 5, 10),
                            Email = "client2@example.com",
                            Name = "Client 2",
                            PhoneNumber = "09876543210",
                            RegisteredIn = new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(6856)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Function")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Function = 2,
                            Name = "Employee 1",
                            Password = "Dev@123",
                            User = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Function = 0,
                            Name = "Employee 2",
                            Password = "Dev@123",
                            User = "Dev"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ingredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ProductId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2m,
                            MaterialId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1m,
                            MaterialId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 0.200m,
                            MaterialId = 3,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 4,
                            Amount = 1m,
                            MaterialId = 4,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 5,
                            Amount = 2m,
                            MaterialId = 5,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 6,
                            Amount = 1m,
                            MaterialId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 7,
                            Amount = 1m,
                            MaterialId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 8,
                            Amount = 0.300m,
                            MaterialId = 3,
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinimumQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100m,
                            MinimumQuantity = 20m,
                            Name = "Bife Bovino",
                            PurchasePrice = 1.50m
                        },
                        new
                        {
                            Id = 2,
                            Amount = 100m,
                            MinimumQuantity = 20m,
                            Name = "Pao de Hamburguer",
                            PurchasePrice = 1.00m
                        },
                        new
                        {
                            Id = 3,
                            Amount = 2000m,
                            MinimumQuantity = 200m,
                            Name = "Bacon",
                            PurchasePrice = 1.00m
                        },
                        new
                        {
                            Id = 4,
                            Amount = 2000m,
                            MinimumQuantity = 200m,
                            Name = "Cheddar",
                            PurchasePrice = 1.00m
                        },
                        new
                        {
                            Id = 5,
                            Amount = 2000m,
                            MinimumQuantity = 200m,
                            Name = "Ovo",
                            PurchasePrice = 0.50m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 10,
                            Code = new Guid("9e93f7be-7fc5-4e22-a401-79a587405315"),
                            Name = "X-Tudo",
                            Price = 20m
                        },
                        new
                        {
                            Id = 2,
                            Amount = 15,
                            Code = new Guid("6118bb44-5cd2-4ec3-bc97-b930b520949e"),
                            Name = "X-Egg-Bacon",
                            Price = 18m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusPayment")
                        .HasColumnType("int");

                    b.Property<int>("StatusSale")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypePayment")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Discount = 0m,
                            EmployeeId = 1,
                            SaleDate = new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(7360),
                            StatusPayment = 1,
                            StatusSale = 4,
                            TotalValue = 400m,
                            TypePayment = 3
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 2,
                            Discount = 50m,
                            EmployeeId = 2,
                            SaleDate = new DateTime(2024, 9, 4, 15, 24, 22, 776, DateTimeKind.Local).AddTicks(7366),
                            StatusPayment = 0,
                            StatusSale = 0,
                            TotalValue = 600m,
                            TypePayment = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.SaleProduct", b =>
                {
                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("SaleId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleProduct");

                    b.HasData(
                        new
                        {
                            SaleId = 1,
                            ProductId = 1,
                            Amount = 2,
                            Id = 1
                        },
                        new
                        {
                            SaleId = 1,
                            ProductId = 2,
                            Amount = 1,
                            Id = 2
                        },
                        new
                        {
                            SaleId = 2,
                            ProductId = 1,
                            Amount = 1,
                            Id = 3
                        },
                        new
                        {
                            SaleId = 2,
                            ProductId = 2,
                            Amount = 2,
                            Id = 4
                        });
                });

            modelBuilder.Entity("Domain.Entities.Cart", b =>
                {
                    b.HasOne("Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Ingredients", b =>
                {
                    b.HasOne("Domain.Entities.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Sale", b =>
                {
                    b.HasOne("Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.SaleProduct", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });
#pragma warning restore 612, 618
        }
    }
}
