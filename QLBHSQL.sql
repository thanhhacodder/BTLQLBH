USE [master]
BEGIN
    CREATE DATABASE [QLBH2];
END;
GO

USE [QLBH2];
GO
/****** Object:  Table [dbo].[BaoCao]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCao](
	[MaBaoCao] [int] IDENTITY(1,1) NOT NULL,
	[TenBaoCao] [nvarchar](100) NULL,
	[NgayLap] [datetime] NULL,
	[TongDoanhThu] [int] NULL,
 CONSTRAINT [PK_BaoCao] PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [varchar](20) NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[GiamGia] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[TongTien] [int] NULL,
	[NgayLap] [date] NULL,
	[NVLapHD] [nchar](10) NULL,
	[TrangThai] [nvarchar](20) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[CMND] [varchar](15) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[SoDienThoai] [varchar](12) NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaNSX] [int] IDENTITY(1,1) NOT NULL,
	[TenNSX] [nvarchar](50) NULL,
	[XuatXu] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaNSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[HinhAnh] [image] NULL,
	[LoaiSanPham] [int] NULL,
	[NhaSanXuat] [int] NULL,
	[GiaNhap] [int] NULL,
	[GiaBan] [int] NULL,
	[SoLuong] [int] NULL,
	[MoTa] [nvarchar](50) NULL,
	[GiamGia] [int] NULL,
	[NgayNhap] [date] NULL,
	[NhanVienNhapHang] [nchar](10) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 29/11/2024 3:17:46 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTaiKhoan] [varchar](20) NOT NULL,
	[MatKhau] [varchar](20) NULL,
	[MaNV] [nchar](10) NULL,
	[VaiTro] [nvarchar](20) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (1, N'?i?n tho?i')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (2, N'Laptop')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (4, N'Máy l?nh')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (5, N'Ti vi')
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (8, N'T? l?nh')
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [CMND], [DiaChi], [NgaySinh], [SoDienThoai], [TinhTrang]) VALUES (N'NV01      ', N'Nguy?n Thanh Hà ', N'054632758', N'Nam ??nh', CAST(N'2003-11-07' AS Date), N'0166458234', NULL)
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [CMND], [DiaChi], [NgaySinh], [SoDienThoai], [TinhTrang]) VALUES (N'NV02      ', N'Nguy?n Lâm', N'026412387', N'Hà N?i', CAST(N'2003-10-25' AS Date), N'0909325486', NULL)
GO
SET IDENTITY_INSERT [dbo].[NhaSanXuat] ON 
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (1, N'Samsung', N'Hàn Qu?c')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (2, N'Apple', N'M?')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (3, N'Panasonic', N'Nh?t B?n')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (4, N'Dell', N'M?')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (5, N'Asus', N'H?ng Kông')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (6, N'Toshiba', N'Thái Lan')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (7, N'Lenovo', N'Trung Qu?c')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (8, N'HP', N'?ài Loan')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (9, N'LG', N'M?')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (10, N'Xiaomi', N'Trung Qu?c')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (11, N'MSI', N'?ài Loan')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [XuatXu]) VALUES (12, N'Sony', N'Nh?t B?n')
GO
SET IDENTITY_INSERT [dbo].[NhaSanXuat] OFF
GO
INSERT INTO [dbo].[TaiKhoan] ([TenTaiKhoan], [MatKhau], [MaNV], [VaiTro]) 
VALUES (N'admin', N'admin', N'NV01', N'qu?n lý');
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([NVLapHD])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([LoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhanVien] FOREIGN KEY([NhanVienNhapHang])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaSanXuat] FOREIGN KEY([NhaSanXuat])
REFERENCES [dbo].[NhaSanXuat] ([MaNSX])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaSanXuat]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
