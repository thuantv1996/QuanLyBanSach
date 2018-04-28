USE [QuanLyBanSach]
GO
/****** Object:  Table [dbo].[CHITIETCONGNO]    Script Date: 4/28/2018 9:29:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETCONGNO](
	[MaCongNo] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[NoDau] [float] NULL,
	[NoCuoi] [float] NULL,
 CONSTRAINT [PK_CHITIETCONGNO] PRIMARY KEY CLUSTERED 
(
	[MaCongNo] ASC,
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETDIEMDANH]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDIEMDANH](
	[MaDiemDanh] [int] NOT NULL,
	[MaTaiKhoan] [int] NOT NULL,
	[GioBatDau] [int] NULL,
	[GioKetThuc] [int] NULL,
 CONSTRAINT [PK_CHITIETDIEMDANH] PRIMARY KEY CLUSTERED 
(
	[MaDiemDanh] ASC,
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MaHoaDon] [varchar](10) NOT NULL,
	[MaSach] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_CHITIETHOADON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETKHUYENMAI]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETKHUYENMAI](
	[MaTheLoai] [int] NOT NULL,
	[MaKhuyenMai] [varchar](10) NOT NULL,
	[NoiDung] [int] NULL,
 CONSTRAINT [PK_ChiTietKhuyenMai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC,
	[MaKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETPHIEUNHAP]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUNHAP](
	[MaPhieuNhap] [varchar](10) NOT NULL,
	[MaSach] [varchar](10) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_CHITIETPHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETTONKHO]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETTONKHO](
	[MaTonKho] [int] NOT NULL,
	[MaSach] [varchar](10) NOT NULL,
	[TonDau] [int] NULL,
	[TonCuoi] [int] NULL,
 CONSTRAINT [PK_CHITIETTONKHO] PRIMARY KEY CLUSTERED 
(
	[MaTonKho] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONGNO]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONGNO](
	[MaCongNo] [int] IDENTITY(1,1) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
 CONSTRAINT [PK_CONGNO] PRIMARY KEY CLUSTERED 
(
	[MaCongNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DIEMDANH]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIEMDANH](
	[MaDiemDanh] [int] IDENTITY(1,1) NOT NULL,
	[NgayDiemDanh] [date] NULL,
 CONSTRAINT [PK_DIEMDANH] PRIMARY KEY CLUSTERED 
(
	[MaDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHoaDon] [varchar](10) NOT NULL,
	[MaKH] [int] NULL,
	[MaNV] [int] NULL,
	[NgayHoaDon] [date] NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SoDienThoaiKH] [varchar](15) NULL,
	[TienNo] [float] NULL,
	[MaLoaiKH] [varchar](10) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHUYENMAI]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHUYENMAI](
	[MaKhuyenMai] [varchar](10) NOT NULL,
	[TenKhuyenMai] [nvarchar](200) NULL,
	[NgayBatDauKM] [date] NULL,
	[NgayKetThucKM] [date] NULL,
 CONSTRAINT [PK_KhuyenMai] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIKHACHHANG]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIKHACHHANG](
	[MaLoaiKH] [varchar](10) NOT NULL,
	[TenLoaiKH] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAIKHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaLoaiKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAINHANVIEN]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAINHANVIEN](
	[MaLoaiNV] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiNV] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAINHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SoDienThoaiNV] [varchar](15) NULL,
	[CMND] [varchar](12) NULL,
	[MaLoaiNV] [int] NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAXUATBAN]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAXUATBAN](
	[MaNXB] [int] IDENTITY(1,1) NOT NULL,
	[TenNXB] [nvarchar](200) NULL,
	[DiaChiNXB] [nvarchar](200) NULL,
	[SoDienThoaiNXB] [varchar](15) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MaPhieuNhap] [varchar](10) NOT NULL,
	[NgayLap] [date] NULL,
	[MaNV] [int] NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MaSach] [varchar](10) NOT NULL,
	[TenSach] [nvarchar](200) NULL,
	[MoTa] [nvarchar](200) NULL,
	[MaNXB] [int] NULL,
	[MaTheLoai] [int] NULL,
	[SoLuong] [int] NULL,
	[GiaBanSi] [float] NULL,
	[GiaBanLe] [float] NULL,
	[TacGia] [nvarchar](50) NULL,
 CONSTRAINT [PK_SACH] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](20) NULL,
	[MatKhau] [char](32) NULL,
	[MaNV] [int] NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAI]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[MaTheLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenTheLoai] [nvarchar](200) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TONKHO]    Script Date: 4/28/2018 9:29:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TONKHO](
	[MaTonKho] [int] IDENTITY(1,1) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
 CONSTRAINT [PK_TONKHO] PRIMARY KEY CLUSTERED 
(
	[MaTonKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHITIETCONGNO]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETCONGNO_CONGNO] FOREIGN KEY([MaCongNo])
REFERENCES [dbo].[CONGNO] ([MaCongNo])
GO
ALTER TABLE [dbo].[CHITIETCONGNO] CHECK CONSTRAINT [FK_CHITIETCONGNO_CONGNO]
GO
ALTER TABLE [dbo].[CHITIETCONGNO]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETCONGNO_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[CHITIETCONGNO] CHECK CONSTRAINT [FK_CHITIETCONGNO_KHACHHANG]
GO
ALTER TABLE [dbo].[CHITIETDIEMDANH]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDIEMDANH_DIEMDANH] FOREIGN KEY([MaDiemDanh])
REFERENCES [dbo].[DIEMDANH] ([MaDiemDanh])
GO
ALTER TABLE [dbo].[CHITIETDIEMDANH] CHECK CONSTRAINT [FK_CHITIETDIEMDANH_DIEMDANH]
GO
ALTER TABLE [dbo].[CHITIETDIEMDANH]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDIEMDANH_TAIKHOAN] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TAIKHOAN] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[CHITIETDIEMDANH] CHECK CONSTRAINT [FK_CHITIETDIEMDANH_TAIKHOAN]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_HOADON] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HOADON] ([MaHoaDon])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_HOADON]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_SACH] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_SACH]
GO
ALTER TABLE [dbo].[CHITIETKHUYENMAI]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETKHUYENMAI_KHUYENMAI] FOREIGN KEY([MaKhuyenMai])
REFERENCES [dbo].[KHUYENMAI] ([MaKhuyenMai])
GO
ALTER TABLE [dbo].[CHITIETKHUYENMAI] CHECK CONSTRAINT [FK_CHITIETKHUYENMAI_KHUYENMAI]
GO
ALTER TABLE [dbo].[CHITIETKHUYENMAI]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETKHUYENMAI_THELOAI] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[THELOAI] ([MaTheLoai])
GO
ALTER TABLE [dbo].[CHITIETKHUYENMAI] CHECK CONSTRAINT [FK_CHITIETKHUYENMAI_THELOAI]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP_PHIEUNHAP] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PHIEUNHAP] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP_PHIEUNHAP]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP_SACH] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP_SACH]
GO
ALTER TABLE [dbo].[CHITIETTONKHO]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETTONKHO_SACH] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[CHITIETTONKHO] CHECK CONSTRAINT [FK_CHITIETTONKHO_SACH]
GO
ALTER TABLE [dbo].[CHITIETTONKHO]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETTONKHO_TONKHO] FOREIGN KEY([MaTonKho])
REFERENCES [dbo].[TONKHO] ([MaTonKho])
GO
ALTER TABLE [dbo].[CHITIETTONKHO] CHECK CONSTRAINT [FK_CHITIETTONKHO_TONKHO]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KHACHHANG]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHANVIEN]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK_KHACHHANG_LOAIKHACHHANG] FOREIGN KEY([MaLoaiKH])
REFERENCES [dbo].[LOAIKHACHHANG] ([MaLoaiKH])
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [FK_KHACHHANG_LOAIKHACHHANG]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_LOAINHANVIEN] FOREIGN KEY([MaLoaiNV])
REFERENCES [dbo].[LOAINHANVIEN] ([MaLoaiNV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_LOAINHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP_NHANVIEN]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_NHAXUATBAN] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NHAXUATBAN] ([MaNXB])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_NHAXUATBAN]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_THELOAI] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[THELOAI] ([MaTheLoai])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_THELOAI]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_NHANVIEN]
GO
