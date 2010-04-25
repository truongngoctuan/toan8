using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace ChonVaHienThiBaiHoc
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ReadFile rf;
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rf = new ReadFile();
            string[] filename = rf.LoadFiles();
            //richTextBox1.Name = filename[0]; //thay bang su lua chon bai hoc

            MessageBox.Show(filename[0] - "Lessons/");
            rf.LoadRTFPackage(filename[0], richTextBox1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
