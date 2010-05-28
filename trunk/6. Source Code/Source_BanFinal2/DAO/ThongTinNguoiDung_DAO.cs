using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace DAO
{
    public class ThongTinNguoiDung_DAO
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

    }
}
