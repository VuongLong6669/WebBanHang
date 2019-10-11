namespace WebBanHang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DbSet<ChiTietDonDatHangNCC> ChiTietDonDatHangNCCs { get; set; }
        public virtual DbSet<ChiTietTraHangNCC> ChiTietTraHangNCCs { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<DonDatHangNCC> DonDatHangNCCs { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomNhanVien> NhomNhanViens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<Quyen_NV> Quyen_NV { get; set; }
        public virtual DbSet<TraHangNCC> TraHangNCCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .Property(e => e.GioiTinhKhachHang)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.UserNameNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.IdNhomNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.PasswordNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoaiNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.ChungMinhNhanDanNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.EmailNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.GioiTinhNhanVien)
                .IsFixedLength();

            modelBuilder.Entity<NhomNhanVien>()
                .Property(e => e.IdNhomNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NhomNhanVien>()
                .Property(e => e.TenNhomNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.IdQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.TenQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen_NV>()
                .Property(e => e.IdQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen_NV>()
                .Property(e => e.IdNhomNhanVien)
                .IsUnicode(false);
        }
    }
}
