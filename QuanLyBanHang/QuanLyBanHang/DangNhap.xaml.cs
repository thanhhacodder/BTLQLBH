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
using System.Windows.Shapes;

namespace QuanLyBanHang
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        QLBHEntities db = new QLBHEntities();

        public DangNhap()
        {
            InitializeComponent();
        }


        private void BtnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Tài khoản không được để trống !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                txtTaiKhoan.Focus();
                return;
            }

            if (passMatKhau.Password == "")
            {
                MessageBox.Show("Mật khẩu không được để trống !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                passMatKhau.Focus();
                return;
            }

            try
            {
                TaiKhoan tk = db.TaiKhoans.SingleOrDefault(t => t.TenTaiKhoan == txtTaiKhoan.Text && t.MatKhau == passMatKhau.Password);

                if (tk != null)
                {
                    //MessageBox.Show("Đăng nhập thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    var form = new MainWindow();
                    form.maNV = tk.MaNV;
                    form.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtTaiKhoan.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Đăng nhập thất bại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
