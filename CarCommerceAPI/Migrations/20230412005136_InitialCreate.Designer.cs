﻿// <auto-generated />
using CarCommerceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarCommerceAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230412005136_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarCommerceAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Auction")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumSeats")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Car");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CarCommerceAPI.Models.Electric", b =>
                {
                    b.HasBaseType("CarCommerceAPI.Models.Car");

                    b.Property<string>("ChargeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Electric");
                });

            modelBuilder.Entity("CarCommerceAPI.Models.Ute", b =>
                {
                    b.HasBaseType("CarCommerceAPI.Models.Car");

                    b.Property<int>("TowingCapactity")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Ute");
                });

            modelBuilder.Entity("CarCommerceAPI.Models.Van", b =>
                {
                    b.HasBaseType("CarCommerceAPI.Models.Car");

                    b.Property<int>("CargoVolume")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Van");
                });
#pragma warning restore 612, 618
        }
    }
}