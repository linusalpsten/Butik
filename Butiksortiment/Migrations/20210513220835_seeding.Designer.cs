﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreAssortment.DB;

namespace StoreAssortment.Migrations
{
    [DbContext(typeof(StoreAssortmentContext))]
    [Migration("20210513220835_seeding")]
    partial class seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreAssortment.DB.StoreAssortmentItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("StoreAssortmentItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3873c080-9a02-4891-a316-f07a776f71cf"),
                            Description = "Delikata frysta kycklingspett marinerade i chilisås",
                            Name = "Kycklingspett",
                            Price = 100m
                        },
                        new
                        {
                            Id = new Guid("dff3bd4f-7629-440f-882d-90c466b74860"),
                            Description = "God lasagne",
                            Name = "Lasagne",
                            Price = 70m
                        },
                        new
                        {
                            Id = new Guid("85ca08be-fe9e-4e42-822e-af188fb62209"),
                            Description = "Vacker tårta med tre lager glass på en god nötbotten",
                            Name = "Glasstårta",
                            Price = 150m
                        },
                        new
                        {
                            Id = new Guid("b246cc1b-ee71-4ae6-9cc1-4dfc2ab15946"),
                            Description = "Smulig äppelpaj som är magiskt god",
                            Name = "Äppelpaj",
                            Price = 140m
                        },
                        new
                        {
                            Id = new Guid("7cbdf4e6-60a2-45de-a3b3-8de8c9c52837"),
                            Description = "Finskuren pyttipanna",
                            Name = "Pyttipanna",
                            Price = 90m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
