using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary1.Models
{
    public partial class CuaHangGiayDBContext : DbContext
    {
        public CuaHangGiayDBContext()
        {
        }

        public CuaHangGiayDBContext(DbContextOptions<CuaHangGiayDBContext> options)
            : base(options)
        {
        }

        public  DbSet<ChiTietSp> ChiTietSps { get; set; } = null!;
        public  DbSet<GioHang> GioHangs { get; set; } = null!;
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; } = null!;
        public  DbSet<HoaDon> HoaDons { get; set; } = null!;
        public  DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; } = null!;
        public DbSet<KichCo> KichCos { get; set; } = null!;
        public  DbSet<KieuSp> KieuSps { get; set; } = null!;
        public  DbSet<MauSac> MauSacs { get; set; } = null!;
        public  DbSet<Role> Roles { get; set; } = null!;
        public  DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MI\\SQLEXPRESS;Database=CuaHangGiay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietSp>(entity =>
            {
                entity.ToTable("ChiTietSP");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ten).HasMaxLength(300).IsRequired();
                entity.Property(e => e.BaoHanh).HasMaxLength(50);
                entity.Property(e => e.LinkAnh).HasMaxLength(500);
                entity.Property(e => e.GiaBan)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GiaNhap)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");
            
                entity.Property(e => e.SoLuongTon).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdKichCoNavigation)
                    .WithMany(p => p.ChiTietSps)
                    .HasForeignKey(d => d.IdKichCo)
                    .HasConstraintName("FK_ChiTietSP_KichCo");

                entity.HasOne(d => d.IdMauSacNavigation)
                    .WithMany(p => p.ChiTietSps)
                    .HasForeignKey(d => d.IdMauSac)
                    .HasConstraintName("FK_ChiTietSP_MauSac");

                entity.HasOne(d => d.IdKieuSpNavigation)
                   .WithMany(p => p.ChiTietSps)
                   .HasForeignKey(d => d.IdKieuSp)
                   .HasConstraintName("FK_ChiTietSP_KieuSp");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__GioHang__1788CC4CAE7A30E2");

                entity.ToTable("GioHang");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.GioHang)
                    .HasForeignKey<GioHang>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_Users");
            });

            modelBuilder.Entity<GioHangChiTiet>(entity =>
            {
                entity.ToTable("GioHangChiTiet");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DonGia)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdChiTietSpNavigation)
                    .WithMany(p => p.GioHangChiTiets)
                    .HasForeignKey(d => d.IdChiTietSp)
                    .HasConstraintName("FK_GioHangChiTiet_ChiTietSanPham");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GioHangChiTiets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_GioHangChiTiet_GioHang");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.ToTable("HoaDon");

                entity.HasIndex(e => e.Ma, "UQ__HoaDon__3214CC9E404AE3DD")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ma)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTao).HasColumnType("datetime");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__HoaDon__UserId__29221CFB");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.ToTable("HoaDonChiTiet");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DonGia)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdChiTietSp).HasColumnName("IdChiTietSP");
                entity.Property(e => e.DiaChi).HasMaxLength(400);
                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");
                entity.Property(e => e.Sdt)
                   .HasMaxLength(10)
                   .IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
                entity.Property(e => e.Ten).HasMaxLength(100);
                entity.HasOne(d => d.IdChiTietSpNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdChiTietSp)
                    .HasConstraintName("FK_HoaDonChiTiet_ChiTietSP");

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.IdHoaDon)
                    .HasConstraintName("FK_HoaDonChiTiet_HoaDon");
            });

            modelBuilder.Entity<KichCo>(entity =>
            {
                entity.ToTable("KichCo");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<KieuSp>(entity =>
            {
                entity.ToTable("KieuSP");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<MauSac>(entity =>
            {
                entity.ToTable("MauSac");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ten).HasMaxLength(30);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
            });

           

            modelBuilder.Entity<User>(entity =>
            {
              

                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AE7B9593")
                    .IsUnique();

                entity.HasIndex(e => e.TaiKhoan, "UQ__Users__D5B8C7F00050C1C1")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DiaChi).HasMaxLength(300);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ten).HasMaxLength(300);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolesId)
                    .HasConstraintName("FK__Users__RolesId__2A164134");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
