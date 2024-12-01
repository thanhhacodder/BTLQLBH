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
    /// Interaction logic for LoaiSanPham1.xaml
    /// </summary>
    public partial class LoaiSanPham1 : Window
    {
        QLBHEntities db = new QLBHEntities();

        public LoaiSanPham1()
        {
            InitializeComponent();
            try
            {
                this.listView1.ItemsSource = db.LoaiSanPhams.ToList();
                this.listView2.ItemsSource = db.LoaiSanPhams.ToList();
                this.listView3.ItemsSource = db.LoaiSanPhams.ToList();
            }
            catch (Exception) { }
        }

        private void BtnSuaLoaiSP_Click(object sender, RoutedEventArgs e)
        {
            if (listView3.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm trong danh sách bạn cần cập nhật.");
                return;
            }

            if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Tên loại sản phẩm không được để trống.");
                txtTenLoai.Focus();

                return;
            }

            try
            {
                var item = listView3.SelectedItem as LoaiSanPham;
                var listLoaiSP = db.LoaiSanPhams.Where(l => l.MaLoai == item.MaLoai).Single();

                if (listLoaiSP != null)
                {
                    listLoaiSP.TenLoai = txtTenLoai.Text;
                    db.SaveChanges();
                }

                this.Window_Loaded(sender, e);

                MessageBox.Show("Cập nhật loại sản phẩm thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật loại sản phẩm thất bại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void BtnXoaLoaiSP_Click(object sender, RoutedEventArgs e)
        {
            if (listView2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm trong danh sách bạn cần xóa.");
                return;
            }

            try
            {
                var listLoaiSP = new List<LoaiSanPham>();

                foreach (var item in listView2.SelectedItems)
                {
                    if (item != null)
                    {
                        var loaiSP = item as LoaiSanPham;

                        if (db.SanPhams.Where(sp => sp.LoaiSanPham == loaiSP.MaLoai).Count() != 0)
                        {
                            string mesage = "Loại sản phẩm '" + loaiSP.TenLoai.ToString() + "' trong danh sách bạn chọn, còn sản phẩm sử dụng. Không thể xóa !";
                            MessageBox.Show(mesage);
                            return;
                        }
                        listLoaiSP.Add(loaiSP);
                    }
                }

                if (listLoaiSP != null)
                {
                    db.LoaiSanPhams.RemoveRange(listLoaiSP);
                    db.SaveChanges();
                }

                this.Window_Loaded(sender, e);

                MessageBox.Show("Xóa loại sản phẩm thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa loại sản phẩm thất bại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            int a;
            if (int.TryParse(txtTenLoaiSP.Text, out a))
            {
                MessageBox.Show("Tên loại sản phẩm là chuỗi.");
                txtTenLoaiSP.Clear();
                txtTenLoaiSP.Focus();

                return;
            }

            if (txtTenLoaiSP.Text == "")
            {
                MessageBox.Show("Tên loại sản phẩm không được để trống.");
                txtTenLoaiSP.Focus();

                return;
            }

            else if (db.LoaiSanPhams.Where(l => l.TenLoai == txtTenLoaiSP.Text).Count() != 0)
            {
                MessageBox.Show("Tên loại sản phẩm đã tồn tại.");
                txtTenLoaiSP.Focus();

                return;
            }

            try
            {
                var loaiSP = new LoaiSanPham();
                loaiSP.TenLoai = txtTenLoaiSP.Text;

                db.LoaiSanPhams.Add(loaiSP);
                db.SaveChanges();

                txtTenLoaiSP.Clear();
                this.Window_Loaded(sender, e);

                MessageBox.Show("Thêm mới loại sản phẩm thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm mới thất bại !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.listView1.ItemsSource = db.LoaiSanPhams.ToList();
            this.listView2.ItemsSource = db.LoaiSanPhams.ToList();
            this.listView3.ItemsSource = db.LoaiSanPhams.ToList();
        }
    }
}
