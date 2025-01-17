﻿// <auto-generated />
using System;
using LittleThings.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LittleThings.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220817113847_FileUploadChanges")]
    partial class FileUploadChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LittleThings.Shared.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FileUploadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FileUploadId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1e85aeb-4943-4658-a0c4-d0dc27d3485c"),
                            FileUploadId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Shirts",
                            SubCategoryId = new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04")
                        });
                });

            modelBuilder.Entity("LittleThings.Shared.FileUpload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ErrorCode")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoredFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Uploaded")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("FileUpload");
                });

            modelBuilder.Entity("LittleThings.Shared.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Customer"
                        });
                });

            modelBuilder.Entity("LittleThings.Shared.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SocialMedia");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "fab fa-facebook-f",
                            Link = "https://www.facebook.com/"
                        });
                });

            modelBuilder.Entity("LittleThings.Shared.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("SubCategory");

                    b.HasData(
                        new
                        {
                            Id = new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04"),
                            Name = "Mens"
                        });
                });

            modelBuilder.Entity("LittleThings.Shared.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LittleThings.Shared.Category", b =>
                {
                    b.HasOne("LittleThings.Shared.FileUpload", "FileUpload")
                        .WithMany()
                        .HasForeignKey("FileUploadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LittleThings.Shared.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileUpload");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("LittleThings.Shared.User", b =>
                {
                    b.HasOne("LittleThings.Shared.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
