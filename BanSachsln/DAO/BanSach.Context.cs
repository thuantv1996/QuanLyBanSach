﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyBanSachEntities : DbContext
    {
        public QuanLyBanSachEntities()
            : base("name=QuanLyBanSachEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CHITIETCONGNO> CHITIETCONGNOes { get; set; }
        public DbSet<CHITIETDIEMDANH> CHITIETDIEMDANHs { get; set; }
        public DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public DbSet<CHITIETKHUYENMAI> CHITIETKHUYENMAIs { get; set; }
        public DbSet<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public DbSet<CHITIETTONKHO> CHITIETTONKHOes { get; set; }
        public DbSet<CONGNO> CONGNOes { get; set; }
        public DbSet<DIEMDANH> DIEMDANHs { get; set; }
        public DbSet<HOADON> HOADONs { get; set; }
        public DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public DbSet<LOAIKHACHHANG> LOAIKHACHHANGs { get; set; }
        public DbSet<LOAINHANVIEN> LOAINHANVIENs { get; set; }
        public DbSet<NHANVIEN> NHANVIENs { get; set; }
        public DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public DbSet<SACH> SACHes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public DbSet<THELOAI> THELOAIs { get; set; }
        public DbSet<TONKHO> TONKHOes { get; set; }
        public DbSet<THANHTOAN> THANHTOANs { get; set; }
        public DbSet<QUYDINH> QUYDINHs { get; set; }
    }
}
