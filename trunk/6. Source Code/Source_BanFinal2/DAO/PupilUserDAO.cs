using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using DTO;
namespace DAO
{
    public class PupilUserDAO
    {
        #region 4.Retrieving
        public static List<string> LayDanhSachPupilUser()
        {
            List<string> danhSach = new List<string>();
            DirectoryInfo thuMucChuaPupilUser = new DirectoryInfo(PupilUserDTO.DuongDanThuMucPupilAccount);
            DirectoryInfo[] thongTinCacThuMucCon = thuMucChuaPupilUser.GetDirectories();
            foreach (DirectoryInfo thongTinMotThuMuc in thongTinCacThuMucCon)
            {                
                danhSach.Add(thongTinMotThuMuc.Name);
            }
            return danhSach;
        }
        public static bool KiemTraTenDangNhapCoTonTaiKhong(string tenDangNhap)
        {            
            List<string> danhSachPupilUser = new List<string>();
            danhSachPupilUser = LayDanhSachPupilUser();
            bool ketQua = danhSachPupilUser.Contains(tenDangNhap);
            if (ketQua)
                return true;
            return false;
        }
        public static string LayMatKhauCuaTaiKhoan(string tenDangNhap)
        {
            string ketQua = string.Empty;
            string duongDan = string.Concat(PupilUserDTO.DuongDanThuMucPupilAccount, @"/", tenDangNhap,@"/UserInfo.xml");
            XmlTextReader reader = new XmlTextReader(duongDan);
            while(reader.Read())
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
            return ketQua;
        }
        #endregion
    }
}
