﻿// <auto-generated />
using System;
using EnggBlog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnggBlog.DataLayer.Migrations
{
    [DbContext(typeof(EnggBlogContext))]
    partial class EnggBlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFinaly");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderSum");

                    b.Property<int>("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.OrderDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderCount");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductDownloadFileId");

                    b.Property<int>("ProductPrice");

                    b.HasKey("DetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductDownloadFileId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatId");

                    b.Property<string>("Des");

                    b.Property<string>("ImgName")
                        .HasMaxLength(100);

                    b.Property<string>("LatinName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("NumberSeen");

                    b.Property<string>("RefreshDate")
                        .HasMaxLength(100);

                    b.Property<string>("Tags");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.ProductDownloadFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .HasMaxLength(200);

                    b.Property<string>("BlogLang")
                        .HasMaxLength(50);

                    b.Property<string>("FileFormat")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("NumberDownload");

                    b.Property<int>("ProductId");

                    b.Property<int>("ProductPrice");

                    b.Property<string>("RouteAddress");

                    b.Property<string>("SourceName")
                        .HasMaxLength(200);

                    b.Property<string>("TypeName")
                        .HasMaxLength(100);

                    b.Property<string>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDownloadFiles");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(6);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Name")
                        .HasMaxLength(40);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<int>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.UserProductDownloadFile", b =>
                {
                    b.Property<int>("UC_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductDownloadFileId");

                    b.Property<int>("UserId");

                    b.HasKey("UC_Id");

                    b.HasIndex("ProductDownloadFileId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProductDownloadFiles");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<bool>("IsPay");

                    b.Property<int>("TypeId");

                    b.Property<int>("UserId");

                    b.HasKey("WalletId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.WalletType", b =>
                {
                    b.Property<int>("TypeId");

                    b.Property<string>("TypeTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TypeId");

                    b.ToTable("WalletTypes");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Category", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Order", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.OrderDetail", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnggBlog.DataLayer.Entities.ProductDownloadFile", "ProductDownloadFile")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductDownloadFileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Product", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.ProductDownloadFile", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.Product", "Product")
                        .WithMany("ProductDownloadFiles")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.User", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.UserProductDownloadFile", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.ProductDownloadFile", "ProductDownloadFile")
                        .WithMany("UserProductDownloadFiles")
                        .HasForeignKey("ProductDownloadFileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnggBlog.DataLayer.Entities.User", "User")
                        .WithMany("UserProductDownloadFiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EnggBlog.DataLayer.Entities.Wallet", b =>
                {
                    b.HasOne("EnggBlog.DataLayer.Entities.WalletType", "WalletType")
                        .WithMany("Wallets")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EnggBlog.DataLayer.Entities.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
