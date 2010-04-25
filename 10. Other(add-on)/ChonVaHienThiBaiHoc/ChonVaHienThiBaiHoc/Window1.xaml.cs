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
        string[] filename;

        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {          
            string path = "\\" + filename[0]; //lay duong dan cua file bai hoc
            rf.LoadRTFPackage(path, richTextBox1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sbaichon = listBox1.SelectedItem.ToString();


            for (int i = 0; i < filename.Length;i++ )
            {
                if (sbaichon == filename[i])
                {
                    string path = "\\" + filename[i]; //lay duong dan cua file bai hoc
                    rf.LoadRTFPackage(path, richTextBox1);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rf = new ReadFile();
            filename = rf.LoadFiles();
            for (int i = 0; i < filename.Length; i++)
            {
                listBox1.Items.Add(filename[0]);
            } 
        }
    }
}
