using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using DTO;
namespace DAO
{
    public class UserDAO
    {
        public static List<string> LayDanhSachTaiKhoan(string duongDanThuMucChuaTaiKhoan)
        {
            List<string> danhSach = new List<string>();            
            try
            {
                DirectoryInfo thuMucChuaPupilUser = new DirectoryInfo(duongDanThuMucChuaTaiKhoan);
                DirectoryInfo[] thongTinCacThuMucCon = thuMucChuaPupilUser.GetDirectories();
            }
            catch
            {}
            foreach (DirectoryInfo thongTinMotThuMuc in thongTinCacThuMucCon)
            {
                danhSach.Add(thongTinMotThuMuc.Name);
            }
            return danhSach;
        }
        public static bool KiemTraTaiKhoanCoTonTaiHayKhong(string tenDangNhap, string duongDanThuMucChuaTaiKhoan)
        {
            List<string> danhSachUser = new List<string>();
            danhSachUser = LayDanhSachTaiKhoan(duongDanThuMucChuaTaiKhoan);
            bool ketQua = danhSachUser.Contains(tenDangNhap);
            if (ketQua)
                return true;
            return false;
        }
        public static string LayMatKhauCuaTaiKhoan(string tenDangNhap, string duongDanThuMucChuaTaiKhoan)
        {
            string ketQua = string.Empty;
            string duongDan = string.Concat(duongDanThuMucChuaTaiKhoan, @"/", tenDangNhap, @"/UserInfo.xml");
            try
            {
                XmlTextReader reader = new XmlTextReader(duongDan);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "password")
                        {
                            reader.Read();
                            ketQua = reader.Value;
                            break;
                        }
                    }
                }
            }
            catch { }
            return ketQua;
        }
    }
}
