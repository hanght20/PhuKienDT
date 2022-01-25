using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PhuKien.Model.Entities
{
    public partial class PhuKienDTContext : DbContext
    {
        public PhuKienDTContext()
        {
        }

        public PhuKienDTContext(DbContextOptions<PhuKienDTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-MN74J8A;Database=PhuKienDT;Integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.MaDanhMuc)
                    .HasName("PK__Category__B3750887C7462028");

                entity.ToTable("Category");

                entity.Property(e => e.MaDanhMuc).ValueGeneratedNever();

                entity.Property(e => e.TenDanhMuc).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__Customer__88D2F0E59EBC3A56");

                entity.ToTable("Customer");

                entity.Property(e => e.MaKhachHang).ValueGeneratedNever();

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.DiaChi).HasMaxLength(300);

                entity.Property(e => e.DienThoai).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.PassWord).HasMaxLength(30);

                entity.Property(e => e.TenKhachHang).HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.MaDonHang)
                    .HasName("PK__Orders__129584AD49C12D1C");

                entity.Property(e => e.MaDonHang).ValueGeneratedNever();

                entity.Property(e => e.GhiChu).HasMaxLength(300);

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MaKhachHang)
                    .HasConstraintName("FK__Orders__MaKhachH__2E1BDC42");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OderDetailId)
                    .HasName("PK__OrderDet__DADCF37667CC906F");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OderDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("OderDetailID");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.MaDonHang)
                    .HasConstraintName("FK__OrderDeta__MaDon__33D4B598");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK__OrderDeta__MaSan__32E0915F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__Product__FAC7442DCDFD7668");

                entity.ToTable("Product");

                entity.Property(e => e.MaSanPham).ValueGeneratedNever();

                entity.Property(e => e.MaNcc).HasColumnName("MaNCC");

                entity.Property(e => e.TenSanPham).HasMaxLength(60);

                entity.HasOne(d => d.MaDanhMucNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MaDanhMuc)
                    .HasConstraintName("FK__Product__MaDanhM__2A4B4B5E");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK__Product__MaNCC__2B3F6F97");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__Supplier__3A185DEBE25512AB");

                entity.ToTable("Supplier");

                entity.Property(e => e.MaNcc)
                    .ValueGeneratedNever()
                    .HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi).HasMaxLength(300);

                entity.Property(e => e.DienThoai).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.TenNcc)
                    .HasMaxLength(100)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Users__A349B042D6162B10");

                entity.Property(e => e.UsersId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsersID");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
