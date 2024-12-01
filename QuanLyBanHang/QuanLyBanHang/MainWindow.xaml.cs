using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyBanHang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLBHEntities db = new QLBHEntities();
        public string maNV { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLoaiSP_Click(object sender, RoutedEventArgs e)
        {
            var form = new LoaiSanPham1();
            form.ShowDialog();
        }

        private void BtnSanPham_Click(object sender, RoutedEventArgs e)
        {
            var form = new SanPham1();
            form.maNhanVien = this.maNV;
            form.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.maNV != "")
            {
                var nv = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == this.maNV);

                tblock.Text = "Xin chào: " + nv.TenNhanVien;
            }
        }

        private void BtnDonHang_Click(object sender, RoutedEventArgs e)
        {
            var form = new DonHang();
            form.Show();
        }

        //private void BtnBieuDo_Click(object sender, RoutedEventArgs e)
        //{
        //    var form = new BieuDo();
        //    form.Show();
        //}
        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            // Mã xử lý đăng xuất
            //var loginWindow = new DangNhap();
            //loginWindow.Show();
            //this.Close();
            MessageBox.Show("Đăng xuất thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(0);
        }

    }
}
