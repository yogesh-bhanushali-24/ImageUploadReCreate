﻿// <auto-generated />
using ImageUploadReCreate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImageUploadReCreate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220222101901_Customer product table")]
    partial class Customerproducttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImageUploadReCreate.Models.Customer", b =>
                {
                    b.Property<int>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cid")
                        .HasColumnType("int");

                    b.Property<string>("Pdetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pprice")
                        .HasColumnType("int");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pid");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("ImageUploadReCreate.Models.Stdcategory", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cid");

                    b.ToTable("stdcategories");
                });

            modelBuilder.Entity("ImageUploadReCreate.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}