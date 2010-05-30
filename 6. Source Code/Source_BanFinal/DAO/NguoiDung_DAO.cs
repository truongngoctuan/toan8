using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using DTO;
namespace DAO
{
    public class NguoiDung_DAO
    {
        public static bool ThemNguoiDungMoi(string duongDan, XElement ThongTinDangKy)
        {
            try
            {
                Directory.CreateDirectory(duongDan);
                duongDan = duongDan+"/ThongTinNguoiDung.xml";
                XDocument taiLieuXml = new XDocument();
                taiLieuXml.Add(ThongTinDangKy);
                taiLieuXml.Save(duongDan);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

//--------------------------------------------------------------
//Phần mới thêm (16-5-2010) - Kiến Minh
//--------------------------------------------------------------
        public static List<string> LayDanhSachTaiKhoan(string duongDanThuMucChuaTaiKhoan)
        {
            List<string> danhSach = new List<string>();
            try
            {
                DirectoryInfo thuMucChuaUser = new DirectoryInfo(duongDanThuMucChuaTaiKhoan);
                DirectoryInfo[] thongTinCacThuMucCon = thuMucChuaUser.GetDirectories();
                foreach (DirectoryInfo thongTinMotThuMuc in thongTinCacThuMucCon)
                {
                    danhSach.Add(thongTinMotThuMuc.Name);
                }
            }
            catch { }
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
            string duongDan = string.Concat(duongDanThuMucChuaTaiKhoan, @"/", tenDangNhap, @"/ThongTinNguoiDung.xml");
            try
            {
                XmlTextReader reader = new XmlTextReader(duongDan);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "MatKhau")
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
        public static NguoiDung_DTO LayThongTinTaiKhoan(string tenDangNhap, string duongDanThuMucChuaTaiKhoan)
        {
            string duongDanFileXML = duongDanThuMucChuaTaiKhoan + @"/" + tenDangNhap + @"/ThongTinNguoiDung.xml";
            XDocument xdoc = XDocument.Load(duongDanFileXML);
            return (from c in xdoc.Descendants("ThongTinNguoiDung")
                    select new NguoiDung_DTO()
                    {
                        UserName = c.Element("TenDangNhap").Value,
                        Password = c.Element("MatKhau").Value,
                        HoTen = c.Element("HoTen").Value,
                        Truong = c.Element("Truong").Value,
                        Lop = c.Element("Lop").Value,
                        Email = c.Element("Email").Value,
                        LoaiNguoiDung = int.Parse(c.Element("LoaiNguoiDung").Value)
                    }).FirstOrDefault();
        }
    }
}
