use master
go
if exists (select name from sysdatabases where name='LKMT')
	drop database LKMT
go
CREATE database LKMT
go
use LKMT


--go
--CREATE FUNCTION AUTO_IDKH()
--RETURNS VARCHAR(5)
--AS
--BEGIN
--DECLARE @ID VARCHAR(5)
--	IF (SELECT COUNT(id_khachhang) FROM KHACHHANG) = 0
--		SET @ID = '0'
--	ELSE
--		SELECT @ID = MAX(RIGHT(id_khachhang, 3)) FROM KHACHHANG
--		SELECT @ID = CASE
--			WHEN @ID >= 0 and @ID < 9 THEN 'KH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 9 THEN 'KH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--		END
--	RETURN @ID
--END

create table admin (
	id_admin int NOT NULL IDENTITY UNIQUE,
	email varchar(40) NOT NULL UNIQUE,
	matkhau varchar(32) NOT NULL,
	ten nvarchar(128) NOT NULL,
	sodienthoai varchar(11) NOT NULL,
	PRIMARY KEY (id_admin)
)

create table khachhang (
	id_khachhang int NOT NULL UNIQUE,
	email varchar(40) NOT NULL UNIQUE,
	matkhau varchar(32) NOT NULL,
	ten nvarchar(128) NOT NULL,
	sodienthoai varchar(11) NOT NULL,
	diachi nvarchar(128) NOT NULL,
	ngaytao date NOT NULL,
	ngaycapnhat date NOT NULL,
	PRIMARY KEY (id_khachhang)
)
create table nhomsanpham (
	id_nhom char(5) NOT NULL UNIQUE,
	tennhom nvarchar(32) NOT NULL,
	ngaytao date NOT NULL,
	ngaycapnhat date NOT NULL,
	PRIMARY KEY (id_nhom)
)
create table loaisanpham (
	id_loai char(5) NOT NULL UNIQUE,
	id_nhom char(5) NOT NULL,
	tenloai nvarchar(32) NOT NULL,
	hinh varchar(128) NOT NULL,
	ngaytao date NOT NULL,
	ngaycapnhat date NOT NULL,
	PRIMARY KEY (id_loai)
)
create table thuonghieu (
	id_thuonghieu int NOT NULL IDENTITY UNIQUE,
	tenthuonghieu nvarchar(40) NOT NULL,
	ngaytao date NOT NULL,
	ngaycapnhat date NOT NULL,
	PRIMARY KEY (id_thuonghieu)
)
create table sanpham (
	id_sanpham char(10) NOT NULL UNIQUE,
	tensanpham nvarchar(52) NOT NULL,
	id_loai char(5) NOT NULL,
	gia decimal(15,4) NOT NULL,
	id_thuonghieu int NOT NULL,
	baohanh int NOT NULL,
	khuyenmai int NOT NULL DEFAULT 0,
	hinh varchar(128) NOT NULL,
	luotxem int NOT NULL,
	mota text NOT NULL,
	ngaytao date NOT NULL,
	ngaycapnhat date NOT NULL,
	PRIMARY KEY (id_sanpham)
)
create table donhang (
	id_donhang char(12) NOT NULL UNIQUE,
	id_khachhang int NOT NULL,
	ngaydathang date NOT NULL,
	id_thanhtoan int NOT NULL,
	tinhtrang nvarchar(20) NOT NULL,
	ghichu nvarchar(158),
	PRIMARY KEY (id_donhang)
)
create table chitietdonhang (
	id_donhang char(12) UNIQUE NOT NULL,
	id_sanpham char(10) NOT NULL,
	dongia decimal(15,4) NOT NULL,
	soluong int NOT NULL,
	PRIMARY KEY (id_donhang, id_sanpham)
)
create table giohang (
	id int NOT NULL UNIQUE IDENTITY,
	id_sanpham char(10) NOT NULL,
	soluong int NOT NULL,
	PRIMARY KEY (id, id_sanpham)
)
create table phieugiaohang (
	id_pgh int NOT NULL IDENTITY,
	ngaygiaohang date NOT NULL,
	diachi nvarchar(50),
	tenkhachhang nvarchar(128) NOT NULL,
	sodienthoai varchar(11) NOT NULL,
	id_donhang char(12) NOT NULL,
	ghichu nvarchar(158),
	phigiaohang decimal(9,0) NOT NULL,
	PRIMARY KEY (id_pgh)
)
create table phuongthucthanhtoan (
	id_thanhtoan int NOT NULL UNIQUE IDENTITY,
	tenthanhtoan nvarchar(48),
	PRIMARY KEY (id_thanhtoan)
)

create table phieunhap (
	id_sanpham char(10) NOT NULL,
	soluongsp int NOT NULL,
	gianhap decimal(15,4) NOT NULL,
	ngaynhap datetime NOT NULL,
	PRIMARY KEY (id_sanpham)
)
create table xuatkho (
	id_sanpham char(10) NOT NULL,
	soluong int NOT NULL,
	ngayxuat date
)
alter table nhapkho add constraint FK_nhapkho_sanpham
foreign key (id_sanpham) references sanpham (id_sanpham);


alter table tonkho add constraint FK_tonkho_sanpham
foreign key (id_sanpham) references sanpham (id_sanpham);


alter table loaisanpham add constraint FK_loaisanpham_nhomsanpham
foreign key (id_nhom) references nhomsanpham (id_nhom);


alter table sanpham add constraint FK_sanpham_loaisanpham
foreign key (id_loai) references loaisanpham (id_loai);


alter table sanpham add constraint FK_sanpham_thuonghieu
foreign key (id_thuonghieu) references thuonghieu (id_thuonghieu);


alter table giohang add constraint FK_giohang_sanpham
foreign key (id_sanpham) references sanpham (id_sanpham);


alter table chitietdonhang add constraint FK_chitietdonhang_sanpham
foreign key (id_sanpham) references sanpham (id_sanpham);


alter table chitietdonhang add constraint FK_chitietdonhang_donhang
foreign key (id_donhang) references donhang (id_donhang);


alter table donhang add constraint FK_donhang_phuongthucthanhtoan
foreign key (id_thanhtoan) references phuongthucthanhtoan (id_thanhtoan);


alter table phieugiaohang add constraint FK_phieugiaohang_donhang
foreign key (id_donhang) references donhang (id_donhang);

alter table donhang add constraint FK_donhang_khachhang
foreign key (id_khachhang) references khachhang (id_khachhang);

USE LKMT 
GO 
ALTER DATABASE LKMT set TRUSTWORTHY ON; 
GO 
EXEC dbo.sp_changedbowner @loginame = N'sa', @map = false 
GO 
sp_configure 'show advanced options', 1; 
GO 
RECONFIGURE; 
GO 
sp_configure 'clr enabled', 1; 
GO 
RECONFIGURE; 
GO