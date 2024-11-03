﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RandomUser.Api.Data;

#nullable disable

namespace RandomUser.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RandomUser.Api.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TIMESTAMP");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(160)");

                    b.Property<string>("Gender")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("Mobile")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(160)");

                    b.Property<string>("Nationality")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
