//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SACH
    {
        public SACH()
        {
            this.CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            this.CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            this.CHITIETTONKHOes = new HashSet<CHITIETTONKHO>();
        }
    
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> MaNXB { get; set; }
        public Nullable<int> MaTheLoai { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> GiaBanSi { get; set; }
        public Nullable<double> GiaBanLe { get; set; }
        public string TacGia { get; set; }
    
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public virtual ICollection<CHITIETTONKHO> CHITIETTONKHOes { get; set; }
        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
        public virtual THELOAI THELOAI { get; set; }
    }
}