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
    
    public partial class CHITIETCONGNO
    {
        public int MaCongNo { get; set; }
        public int MaKH { get; set; }
        public Nullable<double> NoDau { get; set; }
        public Nullable<double> NoCuoi { get; set; }
    
        public virtual CONGNO CONGNO { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
