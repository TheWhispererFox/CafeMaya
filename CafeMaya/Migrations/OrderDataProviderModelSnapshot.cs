﻿// <auto-generated />
using System;
using CafeMaya.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeMaya.Migrations
{
    [DbContext(typeof(OrderDataProvider))]
    partial class OrderDataProviderModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CafeMaya.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CafeMaya.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CafeMaya.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CafeMaya.Models.OrderDelivery", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("OrderDelivery");
                });

            modelBuilder.Entity("CafeMaya.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("CafeMaya.Models.Item", b =>
                {
                    b.HasOne("CafeMaya.Models.Category", null)
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("CafeMaya.Models.OrderDelivery", b =>
                {
                    b.HasOne("CafeMaya.Models.Order", "Order")
                        .WithOne("Delivery")
                        .HasForeignKey("CafeMaya.Models.OrderDelivery", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CafeMaya.Models.OrderItem", b =>
                {
                    b.HasOne("CafeMaya.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeMaya.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("CafeMaya.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CafeMaya.Models.Order", b =>
                {
                    b.Navigation("Delivery");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
