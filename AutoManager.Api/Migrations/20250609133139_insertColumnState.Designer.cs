﻿// <auto-generated />
using System;
using AutoManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoManager.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250609133139_insertColumnState")]
    partial class insertColumnState
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoManager.Core.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateOnly?>("LastMaintenanceDate")
                        .HasColumnType("DATE");

                    b.Property<int?>("Mileage")
                        .HasColumnType("INT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("State")
                        .HasColumnType("INT");

                    b.Property<short>("Type")
                        .HasColumnType("SMALLINT");

                    b.Property<int?>("Year")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
