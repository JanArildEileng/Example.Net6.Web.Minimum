﻿// <auto-generated />
using System;
using ExampleContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Example.Net6.Web.Minimum.Context.Migrations
{
    [DbContext(typeof(ExampleDbContext))]
    [Migration("20220223075452_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("ExampleContext.ExampleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Guid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExampleEntity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 2, 23, 8, 54, 52, 153, DateTimeKind.Local).AddTicks(1525),
                            Guid = new Guid("342acca1-55a1-47e0-8df4-c5c5387c784a")
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 2, 23, 8, 54, 52, 153, DateTimeKind.Local).AddTicks(1576),
                            Guid = new Guid("391d31e8-1aa3-404e-824a-c964f4116ae5")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
