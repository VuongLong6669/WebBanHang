using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartMarketServer.Models
{
    public partial class QuanLyBanHangSieuThiMediaMartContext : DbContext
    {
        public QuanLyBanHangSieuThiMediaMartContext()
        {
        }

        public QuanLyBanHangSieuThiMediaMartContext(DbContextOptions<QuanLyBanHangSieuThiMediaMartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHang { get; set; }
        public virtual DbSet<ChiTietDonDatHangNcc> ChiTietDonDatHangNcc { get; set; }
        public virtual DbSet<ChiTietTraHangNcc> ChiTietTraHangNcc { get; set; }
        public virtual DbSet<DonDatHang> DonDatHang { get; set; }
        public virtual DbSet<DonDatHangNcc> DonDatHangNcc { get; set; }
        public virtual DbSet<HangHoa> HangHoa { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<LoaiHang> LoaiHang { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhomNhanVien> NhomNhanVien { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<QuyenNv> QuyenNv { get; set; }
        public virtual DbSet<TraHangNcc> TraHangNcc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=git.alphawaytech.com,7049;Database=QuanLyBanHangSieuThiMediaMart;User Id=sa;Password=654321aA@;Trusted_Connection=false;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonDatHang>(entity =>
            {
                entity.HasOne(d => d.IdDonDatHangNavigation)
                    .WithMany(p => p.ChiTietDonDatHang)
                    .HasForeignKey(d => d.IdDonDatHang)
                    .HasConstraintName("FK_CT_DDH");

                entity.HasOne(d => d.IdHangHoaNavigation)
                    .WithMany(p => p.ChiTietDonDatHang)
                    .HasForeignKey(d => d.IdHangHoa)
                    .HasConstraintName("FK_CT_HH");
            });

            modelBuilder.Entity<ChiTietDonDatHangNcc>(entity =>
            {
                entity.ToTable("ChiTietDonDatHangNCC");

                entity.Property(e => e.SoLuongDatHangNcc).HasColumnName("SoLuongDatHangNCC");

                entity.HasOne(d => d.IdDonDatHangNhaCungCapNavigation)
                    .WithMany(p => p.ChiTietDonDatHangNcc)
                    .HasForeignKey(d => d.IdDonDatHangNhaCungCap)
                    .HasConstraintName("FK_CTDDHNCC_DDH");

                entity.HasOne(d => d.IdHangHoaNavigation)
                    .WithMany(p => p.ChiTietDonDatHangNcc)
                    .HasForeignKey(d => d.IdHangHoa)
                    .HasConstraintName("FK_CTDDHNCC_HH");
            });

            modelBuilder.Entity<ChiTietTraHangNcc>(entity =>
            {
                entity.ToTable("ChiTietTraHangNCC");

                entity.Property(e => e.IdTraHangNcc).HasColumnName("IdTraHangNCC");

                entity.Property(e => e.LyDoTraHang).HasMaxLength(50);

                entity.HasOne(d => d.IdHangHoaNavigation)
                    .WithMany(p => p.ChiTietTraHangNcc)
                    .HasForeignKey(d => d.IdHangHoa)
                    .HasConstraintName("FK_CTTH_HH");

                entity.HasOne(d => d.IdTraHangNccNavigation)
                    .WithMany(p => p.ChiTietTraHangNcc)
                    .HasForeignKey(d => d.IdTraHangNcc)
                    .HasConstraintName("FK_CTTH_THNCC");
            });

            modelBuilder.Entity<DonDatHang>(entity =>
            {
                entity.HasKey(e => e.IdDonDatHang);

                entity.Property(e => e.DiaChiNhanHang).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(256);

                entity.Property(e => e.NgayTaoDonDatHang).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianNhanHang).HasColumnType("date");

                entity.HasOne(d => d.IdKhachHangNavigation)
                    .WithMany(p => p.DonDatHang)
                    .HasForeignKey(d => d.IdKhachHang)
                    .HasConstraintName("FK_DDH_KH");
            });

            modelBuilder.Entity<DonDatHangNcc>(entity =>
            {
                entity.HasKey(e => e.IdDonDatHangNhaCungCap);

                entity.ToTable("DonDatHangNCC");

                entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(50);

                entity.Property(e => e.HinhThucThanhToan).HasMaxLength(50);

                entity.Property(e => e.NgayDatHangNhaCungCap).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianGiaoHang).HasMaxLength(50);

                entity.Property(e => e.TinhTrangDonDatHangNcc).HasColumnName("TinhTrangDonDatHangNCC");

                entity.HasOne(d => d.IdNhaCungCapNavigation)
                    .WithMany(p => p.DonDatHangNcc)
                    .HasForeignKey(d => d.IdNhaCungCap)
                    .HasConstraintName("FK_DDH_NCC");
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.IdHangHoa);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Dvt)
                    .HasColumnName("DVT")
                    .HasMaxLength(50);

                entity.Property(e => e.TenHangHoa).HasMaxLength(50);

                entity.HasOne(d => d.IdLoaiHangNavigation)
                    .WithMany(p => p.HangHoa)
                    .HasForeignKey(d => d.IdLoaiHang)
                    .HasConstraintName("FK_HH_LH");

                entity.HasOne(d => d.IdVoucherNavigation)
                    .WithMany(p => p.HangHoa)
                    .HasForeignKey(d => d.IdVoucher)
                    .HasConstraintName("FK_HH_GD");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.IdKhachHang);

                entity.Property(e => e.Avatar).HasMaxLength(128);

                entity.Property(e => e.DiaChiKhachHang).HasMaxLength(50);

                entity.Property(e => e.EmailKhachHang).HasMaxLength(50);

                entity.Property(e => e.GioiTinhKhachHang).HasMaxLength(5);

                entity.Property(e => e.NgaySinhKhachHang).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoaiKhachHang).HasMaxLength(50);

                entity.Property(e => e.TenKhachHang).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasKey(e => e.IdVoucher);

                entity.Property(e => e.MoTaVoucher).HasMaxLength(150);

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.NgayTaoVoucher).HasColumnType("datetime");

                entity.Property(e => e.TenVoucher).HasMaxLength(50);
            });

            modelBuilder.Entity<LoaiHang>(entity =>
            {
                entity.HasKey(e => e.IdLoaiHang);

                entity.Property(e => e.Anh).HasMaxLength(256);

                entity.Property(e => e.TenLoaiHang).HasMaxLength(50);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.IdNhaCungCap);

                entity.Property(e => e.DiaChiNhaCungCap).HasMaxLength(50);

                entity.Property(e => e.SoDienThoaiNhaCungCap).HasMaxLength(50);

                entity.Property(e => e.SoTaiKhoanNhaCungCap).HasMaxLength(20);

                entity.Property(e => e.TenNhaCungCap).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.UserNameNhanVien);

                entity.Property(e => e.UserNameNhanVien)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChungMinhNhanDanNhanVien)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChiNhanVien).HasMaxLength(50);

                entity.Property(e => e.EmailNhanVien)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinhNhanVien).HasMaxLength(5);

                entity.Property(e => e.IdNhomNhanVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinhNhanVien).HasColumnType("date");

                entity.Property(e => e.PasswordNhanVien)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoaiNhanVien)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhanVien).HasMaxLength(50);

                entity.HasOne(d => d.IdNhomNhanVienNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.IdNhomNhanVien)
                    .HasConstraintName("FK__NhanVien__IdNhom__60A75C0F");
            });

            modelBuilder.Entity<NhomNhanVien>(entity =>
            {
                entity.HasKey(e => e.IdNhomNhanVien);

                entity.Property(e => e.IdNhomNhanVien)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TenNhomNhanVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.HasKey(e => e.IdQuyen);

                entity.Property(e => e.IdQuyen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TenQuyen)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuyenNv>(entity =>
            {
                entity.ToTable("Quyen_NV");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdNhomNhanVien)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdQuyen)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNhomNhanVienNavigation)
                    .WithMany(p => p.QuyenNv)
                    .HasForeignKey(d => d.IdNhomNhanVien)
                    .HasConstraintName("FK__Quyen_NV__IdNhom__619B8048");

                entity.HasOne(d => d.IdQuyenNavigation)
                    .WithMany(p => p.QuyenNv)
                    .HasForeignKey(d => d.IdQuyen)
                    .HasConstraintName("FK__Quyen_NV__IdQuye__628FA481");
            });

            modelBuilder.Entity<TraHangNcc>(entity =>
            {
                entity.HasKey(e => e.IdTraHangNcc);

                entity.ToTable("TraHangNCC");

                entity.Property(e => e.IdTraHangNcc).HasColumnName("IdTraHangNCC");

                entity.Property(e => e.NgayTraHang).HasColumnType("date");

                entity.Property(e => e.ThoiGianTraHang).HasMaxLength(50);

                entity.HasOne(d => d.IdDonDatHangNhaCungCapNavigation)
                    .WithMany(p => p.TraHangNcc)
                    .HasForeignKey(d => d.IdDonDatHangNhaCungCap)
                    .HasConstraintName("FK_DTH_DDH");
            });
        }
    }
}
