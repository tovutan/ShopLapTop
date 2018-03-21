namespace ShopLapTop.Areas.Admin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class laptop : DbContext
    {
        public laptop()
            : base("name=laptop")
        {
        }

        public virtual DbSet<CT_HoaDon> CT_HoaDon { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Loai> Loais { get; set; }
        public virtual DbSet<Nhanhieu> Nhanhieux { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserGroup>  UserGroups{ get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<ChildCategory> ChildCategories { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CT_HoaDon>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hoadon>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Hoadon>()
                .Property(e => e.TrigiaHD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hoadon>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.Hoadon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<Nhanhieu>()
                .Property(e => e.hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.cpu)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.vga)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.ram)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.hdd)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.ssd)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.manhinh)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.cd_dvd)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Giakhuyenmai)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<taikhoan>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<taikhoan>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
