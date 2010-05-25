using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using DAO;

namespace BUS
{
    public class ThongTinNguoiDung_BUS
    {
        
        public static bool KiemTraUserNameCoTonTaiChua(string tenDangNhap)
        {
            string duongDanHocSinh = "Account/PupilUserAccount/" + tenDangNhap;
            string duongDanGiaoVien = "Account/TeacherUserAccount/" + tenDangNhap;
            bool laHopLe = Directory.Exists(duongDanHocSinh);
            if (laHopLe == false)
            {
                laHopLe = Directory.Exists(duongDanGiaoVien);
            }
            return laHopLe;
        }
        public static int ThemNguoiDungMoi(XElement ThongTinDangKy)
        {
            int ketQua = 0;
            bool daTonTai;
            string tenDangNhap = (string)ThongTinDangKy.Element("TenDangNhap");
            string matKhau = (string)ThongTinDangKy.Element("MatKhau");
            string duongDan = "Account/PupilUserAccount/" + tenDangNhap;
            //daTonTai = Directory.Exists(duongDan);
            daTonTai = KiemTraUserNameCoTonTaiChua(tenDangNhap);
            if (daTonTai == true)
            {
                ketQua = 1;
            }
            if (((tenDangNhap.Length) < 6) || (matKhau.Length<8))
            {
                ketQua = -1;
            }
            if (ketQua == 0)
            {
                DAO.ThongTinNguoiDung_DAO.ThemNguoiDungMoi(duongDan,ThongTinDangKy);
            }
            return ketQua;
        }
    }
}
