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
    
    public partial class CHITIETKHUYENMAI
    {
        public int MaTheLoai { get; set; }
        public string MaKhuyenMai { get; set; }
        public Nullable<int> NoiDung { get; set; }
    
        public virtual KHUYENMAI KHUYENMAI { get; set; }
        public virtual THELOAI THELOAI { get; set; }
    }
}
