USE master
GO
CREATE DATABASE PhuKienDT
GO
USE PhuKienDT
GO
CREATE TABLE Category
(
	MaDanhMuc INT PRIMARY KEY,
	TenDanhMuc NVARCHAR(50)
)
GO
CREATE TABLE Customer
(
	MaKhachHang INT PRIMARY KEY,
    TenKhachHang NVARCHAR(100),
    GioiTinh BIT,
    DiaChi NVARCHAR(300),
    DienThoai NVARCHAR(10),
    Email NVARCHAR(30),
    UserName VARCHAR(30),
    [PassWord] NVARCHAR(30),
    Avatar VARCHAR(MAX)
)
GO
CREATE TABLE Supplier
(
	MaNCC INT PRIMARY KEY,
	TenNCC NVARCHAR(100),
	DiaChi NVARCHAR(300),
	Email NVARCHAR(50),
	DienThoai NVARCHAR(10)
)
GO
CREATE TABLE Product
(
	MaSanPham INT PRIMARY KEY,
    TenSanPham NVARCHAR(60),
    Gia FLOAT,
	Anh NVARCHAR(MAX),
	MoTa NVARCHAR(MAX),
	MaDanhMuc INT FOREIGN KEY REFERENCES Category(MaDanhMuc),
	MaNCC INT FOREIGN KEY REFERENCES Supplier(MaNCC)
)
GO
CREATE TABLE Orders
(
	MaDonHang INT PRIMARY KEY,
	MaKhachHang INT FOREIGN KEY REFERENCES Customer(MaKhachHang),
	TongTien FLOAT,
	NgayDat DATETIME,
	GhiChu NVARCHAR(300)
)
GO
CREATE TABLE Users
(
	UsersID INT PRIMARY KEY,
	UserName VARCHAR(50),
	[Password] VARCHAR(20),
	FullName NVARCHAR(200),
	Avatar VARCHAR(MAX),
	Email VARCHAR(50),
	Active BIT
)
GO 
CREATE TABLE OrderDetail
(
	OderDetailID INT PRIMARY KEY,
	MaSanPham INT FOREIGN KEY REFERENCES Product(MaSanPham),
	MaDonHang INT FOREIGN KEY REFERENCES Orders(MaDonHang),
	SoLuong INT
)