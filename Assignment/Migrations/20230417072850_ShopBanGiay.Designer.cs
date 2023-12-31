﻿// <auto-generated />
using System;
using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Migrations
{
    [DbContext(typeof(CuaHangGiayDBContext))]
    [Migration("20230417072850_ShopBanGiay")]
    partial class ShopBanGiay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClassLibrary1.Models.ChiTietSp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("BaoHanh")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("GiaBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasDefaultValueSql("((0))");

                    b.Property<decimal?>("GiaNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid?>("IdKichCo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdKieuSp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdMauSac")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkAnh")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoLuongTon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("IdKichCo");

                    b.HasIndex("IdKieuSp");

                    b.HasIndex("IdMauSac");

                    b.ToTable("ChiTietSP", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.GioHang", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("UserId")
                        .HasName("PK__GioHang__1788CC4CAE7A30E2");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.GioHangChiTiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal?>("DonGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid>("IdChiTietSp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SoLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdChiTietSp");

                    b.HasIndex("UserId");

                    b.ToTable("GioHangChiTiet", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.HoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ma")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Ma" }, "UQ__HoaDon__3214CC9E404AE3DD")
                        .IsUnique()
                        .HasFilter("[Ma] IS NOT NULL");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.HoaDonChiTiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<decimal?>("DonGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,0)")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid?>("IdChiTietSp")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdChiTietSP");

                    b.Property<Guid?>("IdHoaDon")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sdt")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("SoLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Ten")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("IdChiTietSp");

                    b.HasIndex("IdHoaDon");

                    b.ToTable("HoaDonChiTiet", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.KichCo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("KichCo", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.KieuSp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("KieuSP", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.MauSac", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("MauSac", (string)null);
                });

            modelBuilder.Entity("ClassLibrary1.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ClassLibrary1.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("GioiTinh")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MatKhau")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sdt")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TaiKhoan")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Ten")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534AE7B9593")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex(new[] { "TaiKhoan" }, "UQ__Users__D5B8C7F00050C1C1")
                        .IsUnique()
                        .HasFilter("[TaiKhoan] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClassLibrary1.Models.ChiTietSp", b =>
                {
                    b.HasOne("ClassLibrary1.Models.KichCo", "IdKichCoNavigation")
                        .WithMany("ChiTietSps")
                        .HasForeignKey("IdKichCo")
                        .HasConstraintName("FK_ChiTietSP_KichCo");

                    b.HasOne("ClassLibrary1.Models.KieuSp", "IdKieuSpNavigation")
                        .WithMany("ChiTietSps")
                        .HasForeignKey("IdKieuSp")
                        .HasConstraintName("FK_ChiTietSP_KieuSp");

                    b.HasOne("ClassLibrary1.Models.MauSac", "IdMauSacNavigation")
                        .WithMany("ChiTietSps")
                        .HasForeignKey("IdMauSac")
                        .HasConstraintName("FK_ChiTietSP_MauSac");

                    b.Navigation("IdKichCoNavigation");

                    b.Navigation("IdKieuSpNavigation");

                    b.Navigation("IdMauSacNavigation");
                });

            modelBuilder.Entity("ClassLibrary1.Models.GioHang", b =>
                {
                    b.HasOne("ClassLibrary1.Models.User", "User")
                        .WithOne("GioHang")
                        .HasForeignKey("ClassLibrary1.Models.GioHang", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK_GioHang_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClassLibrary1.Models.GioHangChiTiet", b =>
                {
                    b.HasOne("ClassLibrary1.Models.ChiTietSp", "IdChiTietSpNavigation")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdChiTietSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_GioHangChiTiet_ChiTietSanPham");

                    b.HasOne("ClassLibrary1.Models.GioHang", "User")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_GioHangChiTiet_GioHang");

                    b.Navigation("IdChiTietSpNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClassLibrary1.Models.HoaDon", b =>
                {
                    b.HasOne("ClassLibrary1.Models.User", "User")
                        .WithMany("HoaDons")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__HoaDon__UserId__29221CFB");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClassLibrary1.Models.HoaDonChiTiet", b =>
                {
                    b.HasOne("ClassLibrary1.Models.ChiTietSp", "IdChiTietSpNavigation")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdChiTietSp")
                        .HasConstraintName("FK_HoaDonChiTiet_ChiTietSP");

                    b.HasOne("ClassLibrary1.Models.HoaDon", "IdHoaDonNavigation")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdHoaDon")
                        .HasConstraintName("FK_HoaDonChiTiet_HoaDon");

                    b.Navigation("IdChiTietSpNavigation");

                    b.Navigation("IdHoaDonNavigation");
                });

            modelBuilder.Entity("ClassLibrary1.Models.User", b =>
                {
                    b.HasOne("ClassLibrary1.Models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RolesId")
                        .HasConstraintName("FK__Users__RolesId__2A164134");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ClassLibrary1.Models.ChiTietSp", b =>
                {
                    b.Navigation("GioHangChiTiets");

                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("ClassLibrary1.Models.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiets");
                });

            modelBuilder.Entity("ClassLibrary1.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("ClassLibrary1.Models.KichCo", b =>
                {
                    b.Navigation("ChiTietSps");
                });

            modelBuilder.Entity("ClassLibrary1.Models.KieuSp", b =>
                {
                    b.Navigation("ChiTietSps");
                });

            modelBuilder.Entity("ClassLibrary1.Models.MauSac", b =>
                {
                    b.Navigation("ChiTietSps");
                });

            modelBuilder.Entity("ClassLibrary1.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ClassLibrary1.Models.User", b =>
                {
                    b.Navigation("GioHang");

                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
