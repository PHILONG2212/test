using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project2.Entities;

public partial class TourdulichContext : DbContext
{
    public TourdulichContext()
    {
    }

    public TourdulichContext(DbContextOptions<TourdulichContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<CauHinh> CauHinhs { get; set; }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhachSan> KhachSans { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<YeuThich> YeuThiches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PHILONG;Initial Catalog=tourdulich;Integrated Security=True;Trusted_Connection=SSPI;Encrypt=False;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Admin");

            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
        });

        modelBuilder.Entity<CauHinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CauHinh");

            entity.Property(e => e.SoNgayHetHanQc).HasColumnName("SoNgayHetHanQC");
        });

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK_OrderDetails");

            entity.ToTable("ChiTietHD");

            entity.Property(e => e.MaCt).HasColumnName("MaCT");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.SoLuong).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.MaTourNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaTour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK_Orders");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.CachThanhToan)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'Cash')");
            entity.Property(e => e.CachVanChuyen)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'Airline')");
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaVn)
                .HasMaxLength(50)
                .HasColumnName("MaVN");
            entity.Property(e => e.NgayCan)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayDat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayGiao)
                .HasDefaultValueSql("(((1)/(1))/(1900))")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK_Customers");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.DienThoai).HasMaxLength(24);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'Photo.gif')");
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<KhachSan>(entity =>
        {
            entity.HasKey(e => e.MaKhachSan).HasName("PK_Suppliers");

            entity.ToTable("KhachSan");

            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.NguoiLienLac).HasMaxLength(50);
            entity.Property(e => e.TenKhachSan).HasMaxLength(50);
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK_Categories");

            entity.ToTable("Loai");

            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NguoiDung");

            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.DienThoai).HasMaxLength(24);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaNd)
                .HasMaxLength(20)
                .HasColumnName("MaND");
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.MaTour).HasName("PK_Products");

            entity.ToTable("Tour");

            entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");
            entity.Property(e => e.GiamGia).HasDefaultValueSql("((0))");
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.NgayKhoiHanh)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoLanXem).HasDefaultValueSql("((0))");
            entity.Property(e => e.TenTour).HasMaxLength(40);

            entity.HasOne(d => d.MaKhachSanNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.MaKhachSan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_Suppliers");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<YeuThich>(entity =>
        {
            entity.HasKey(e => e.MaYt).HasName("PK_Favorites");

            entity.ToTable("YeuThich");

            entity.Property(e => e.MaYt).HasColumnName("MaYT");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayChon).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.YeuThiches)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Favorites_Customers");

            entity.HasOne(d => d.MaTourNavigation).WithMany(p => p.YeuThiches)
                .HasForeignKey(d => d.MaTour)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_YeuThich_Tour");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
