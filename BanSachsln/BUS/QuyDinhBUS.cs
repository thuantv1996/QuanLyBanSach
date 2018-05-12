using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class QuyDinhBUS
    {
        private static QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public static void LuuQuyDinh(int Tuoi,int No,int SoLuong,int Ton)
        {
            try
            {
                db.QUYDINHs.Find("QD01").NoiDung = Tuoi;
                db.QUYDINHs.Find("QD02").NoiDung = No;
                db.QUYDINHs.Find("QD03").NoiDung = SoLuong;
                db.QUYDINHs.Find("QD04").NoiDung = Ton;
                db.SaveChanges();
            }
            catch { }     
        }
        public static void DanhSachQuyDinh(ref int Tuoi, ref double  No, ref int  SoLuong, ref int  Ton)
        {
            try
            {
                Tuoi = (int)db.QUYDINHs.Find("QD01").NoiDung.Value;
                No = db.QUYDINHs.Find("QD02").NoiDung.Value;
                SoLuong = (int)db.QUYDINHs.Find("QD03").NoiDung.Value;
                Ton =(int)db.QUYDINHs.Find("QD04").NoiDung.Value;
            }
            catch { }
            
        }
    }
}
