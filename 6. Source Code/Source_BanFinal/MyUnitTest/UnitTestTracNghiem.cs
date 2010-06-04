using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using NUnit.Framework;
using ColorSwatch;

namespace MyUnitTest
{
    [TestFixture]
    public class UnitTestTracNghiem
    {
        [Test]
        public void TestLayCauHoi()
        {
            TracNghiem tracNghiem = new TracNghiem();
            //Kiểm tra lấy câu hỏi có số thứ tự 1 ở chương 1 của bài tập đại số:
            tracNghiem.LayCauHoi(AppDomain.CurrentDomain.BaseDirectory +  @"\BaiTapDaiSo\Chuong1\1", "1", 15, 50);
            //Cần biết có lấy được 5 thành phần của câu hay không:
            Assert.AreEqual(5, tracNghiem.m_Cau.Count);
            
            //Kiểm tra các đáp án:
            for (int i = 0; i < tracNghiem.m_DanhSachDapAn.Count; ++i)
            {
                //Đáp án đúng có vị trí là 1:
                Assert.AreEqual(i == 1, tracNghiem.m_DanhSachDapAn[i]);
            }
        }

        [Test]
        public void TestChamDiem()
        { 
            //Đáp án đúng của câu 1 là RadioButton thứ 2:
            //Đáp án đúng của câu 2 là RadioButton thứ 2:
            //Chấm trên thang điểm 1:
            TracNghiem tracNghiem = new TracNghiem();
            tracNghiem.LayCauHoi(AppDomain.CurrentDomain.BaseDirectory  + @"\BaiTapDaiSo\Chuong1\1", "1", 15, 50);

            //Case 1: Không check:
            Assert.AreEqual(0, tracNghiem.ChamDiem(1));

            //Case 2: Check sai:
            ListBoxItem listboxItemcase2 = tracNghiem.m_Cau[1];
            StackPanel stackPanelcase1 = (StackPanel)listboxItemcase2.Content;
            Canvas canvasCase2 = new Canvas();
            canvasCase2 = (Canvas)stackPanelcase1.Children[0];
            RadioButton radioButtoncase2 = (RadioButton)canvasCase2.Children[0];
            radioButtoncase2.IsChecked = true;
            Assert.AreEqual(0, tracNghiem.ChamDiem(1));

            //Case 3: Check đúng:
            ListBoxItem listboxItemcase3 = tracNghiem.m_Cau[2];
            StackPanel stackPanelcase3 = (StackPanel)listboxItemcase3.Content;
            Canvas canvasCase3 = new Canvas();
            canvasCase3 = (Canvas)stackPanelcase3.Children[0];
            RadioButton radioButtoncase3 = (RadioButton)canvasCase3.Children[0];
            radioButtoncase3.IsChecked = true;
            Assert.AreEqual(1, tracNghiem.ChamDiem(1));
        }
    }
}
