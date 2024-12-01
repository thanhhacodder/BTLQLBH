using QuanLyBanHang.Model;
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
    /// Interaction logic for DonHang.xaml
    /// </summary>
    public partial class DonHang : Window
    {
        QLBHEntities db;
        int _trangHienTai = 1, _soLuongDonHangTrenMotTrang = 5, _tongSoTrang;
        public DonHang()
        {
            InitializeComponent();

            db = new QLBHEntities();

            try
            {
                PhanTrangDonHang();
                this.listView2.ItemsSource = GetDanhSachDonHang();
                this.listView3.ItemsSource = GetDanhSachDonHang();
            }
            catch (Exception){ }
        }

        private List<DonHangViewModel> GetDanhSachDonHang()
        {
            var listDonHang = db.HoaDons.Select(x => new DonHangViewModel()
            {
                MaHD = x.MaHD,
                TenKhachHang = x.TenKhachHang,
                TongTien = x.TongTien,
                NgayLap = x.NgayLap,
                NVLapHD = x.NVLapHD,
                NhanVien = x.NhanVien,
                TrangThai = x.TrangThai
            }).OrderByDescending(x => x.MaHD).ToList();

            foreach (var item in listDonHang)
                item.TenNhanVien = GetTenNhanVien(item.NVLapHD);

            return listDonHang;
        }

        private string GetTenNhanVien(string maNhanVien)
        {
            var nhanVien = db.NhanViens.SingleOrDefault(x => x.MaNhanVien == maNhanVien);
            if (nhanVien != null) return nhanVien.TenNhanVien;
            return string.Empty;
        }

        private void BtnTaoDonHang_Click(object sender, RoutedEventArgs e)
        {
            var form = new BanHang();
            form.ShowDialog();
        }

        private void PhanTrangDonHang()
        {
            var tongDonHang = 0;
            var listDonHang = GetDanhSachDonHangPhanTrang(_trangHienTai, _soLuongDonHangTrenMotTrang, out tongDonHang);
            _tongSoTrang = tongDonHang / _soLuongDonHangTrenMotTrang;
            if (tongDonHang % _soLuongDonHangTrenMotTrang > 0)
            {
                _tongSoTrang++;
            }

            this.listView1.ItemsSource = listDonHang;
            AnHienPhanTrang();
        }

        private void BtnTrangTruoc_Click(object sender, RoutedEventArgs e)
        {
            _trangHienTai--;
            if (_trangHienTai > 0)
            {
                var tongDonHang = 0;
                var listDonHang = GetDanhSachDonHangPhanTrang(_trangHienTai, _soLuongDonHangTrenMotTrang, out tongDonHang);
                this.listView1.ItemsSource = listDonHang;
            }
            else
            {
                _trangHienTai = 1;
            }
            AnHienPhanTrang();
        }

        private void BtnTrangSau_Click(object sender, RoutedEventArgs e)
        {
            _trangHienTai++;
            if (_trangHienTai <= _tongSoTrang)
            {
                var tongDonHang = 0;
                var listDonHang = GetDanhSachDonHangPhanTrang(_trangHienTai, _soLuongDonHangTrenMotTrang, out tongDonHang);
                this.listView1.ItemsSource = listDonHang;
            }
            else
            {
                _trangHienTai--;
            }
            AnHienPhanTrang();
        }

        private void BtnTaiDanhSach_Click(object sender, RoutedEventArgs e)
        {
            _trangHienTai = 1;
            PhanTrangDonHang();
        }

        private void BtnXoaDH_Click(object sender, RoutedEventArgs e)
        {
            if (listView2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng trong danh sách bạn cần xóa.");
                return;
            }

            try
            {
                var listDH = new List<HoaDon>();
                var listCTDH = new List<ChiTietHoaDon>();

                foreach (var item in listView2.SelectedItems)
                {
                    if (item != null)
                    {
                        var dhViewModel = item as DonHangViewModel;
                        var dh = db.HoaDons.SingleOrDefault(d => d.MaHD == dhViewModel.MaHD);
                        if (dh == null)
                            continue;

                        var ctdh = db.ChiTietHoaDons.SingleOrDefault(ct => ct.MaHD == dh.MaHD);
                        if (ctdh == null)
                            continue;

                        // thêm vào danh sách xóa đơn hàng và chi tiết đơn hàng
                        listDH.Add(dh);
                        listCTDH.Add(ctdh);
                    }
                }

                if ((listDH != null && listDH.Count > 0) && (listCTDH != null & listCTDH.Count > 0))
                {
                    db.ChiTietHoaDons.RemoveRange(listCTDH);
                    db.HoaDons.RemoveRange(listDH);
                    db.SaveChanges();
                }

                this.Window_Loaded(sender, e);

                MessageBox.Show("Xóa đơn hàng thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Xóa đơn hàng thất bại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PhanTrangDonHang();
            this.listView2.ItemsSource = GetDanhSachDonHang();
            this.listView3.ItemsSource = GetDanhSachDonHang();
        }

        private void BtnTaiDanhSachXoa_Click(object sender, RoutedEventArgs e)
        {
            this.listView2.ItemsSource = GetDanhSachDonHang();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                var itemHD = item.Content as HoaDon;
                if (itemHD != null)
                {
                    if (itemHD.TrangThai == "Mới tạo")
                        cbbItemMoi.IsSelected = true;

                    else if (itemHD.TrangThai == "Đã thanh toán")
                        cbbItemDaThanhToan.IsSelected = true;

                    else if (itemHD.TrangThai == "Đã hủy")
                        cbbItemHuy.IsSelected = true;

                    else
                    {
                        cbbItemMoi.IsSelected = false;
                        cbbItemDaThanhToan.IsSelected = false;
                        cbbItemHuy.IsSelected = false;
                    }
                }
            }
        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (listView3.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng trong danh sách bạn cần cập nhật.");
                return;
            }

            if (cbbTrangThaiDonHang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái của đơn hàng.");
                return;
            }

            try
            {
                var item = listView3.SelectedItem as HoaDon;
                var hd = db.HoaDons.Where(h => h.MaHD == item.MaHD).Single();

                if (hd != null)
                {
                    if (cbbItemMoi.IsSelected)
                        hd.TrangThai = "Mới tạo";
                    else if (cbbItemDaThanhToan.IsSelected)
                        hd.TrangThai = "Đã thanh toán";
                    else if (cbbItemHuy.IsSelected)
                        hd.TrangThai = "Đã hủy";

                    db.SaveChanges();
                }

                this.Window_Loaded(sender, e);

                MessageBox.Show("Cập nhật trạng thái thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                cbbTrangThaiDonHang.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật trạng thái thất bại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void BtnTaiDanhSachSua_Click(object sender, RoutedEventArgs e)
        {
            cbbTrangThaiDonHang.SelectedIndex = -1;
            this.listView3.ItemsSource = GetDanhSachDonHang();
        }

        private List<DonHangViewModel> GetDanhSachDonHangPhanTrang(
            int trangHienTai,
            int donHangTrenMotTrang,
            out int tongDonHang)
        {
            var listDonHang = db.HoaDons
                                .Select(x => new DonHangViewModel()
                                {
                                    MaHD = x.MaHD,
                                    TenKhachHang = x.TenKhachHang,
                                    TongTien = x.TongTien,
                                    NgayLap = x.NgayLap,
                                    NVLapHD = x.NVLapHD,
                                    NhanVien = x.NhanVien,
                                    TrangThai = x.TrangThai
                                })
                            .OrderByDescending(x => x.MaHD)
                            .Skip((trangHienTai - 1) * donHangTrenMotTrang) // lay tu vi tri so 0
                            .Take(donHangTrenMotTrang) // lay 5 san pham
                            .ToList();

            tongDonHang = db.HoaDons.Count(); // lay tong san pham
            foreach (var item in listDonHang)
                item.TenNhanVien = GetTenNhanVien(item.NVLapHD);

            return listDonHang.ToList();
        }

        private void AnHienPhanTrang()
        {
            if (_tongSoTrang == 0)
            {
                btnTrangTruoc.Visibility = btnTrangSau.Visibility = Visibility.Hidden;
                return;
            }

            if (_trangHienTai == 1)
                btnTrangTruoc.Visibility = Visibility.Hidden;
            else
                btnTrangTruoc.Visibility = Visibility.Visible;

            //

            if (_trangHienTai == _tongSoTrang)
                btnTrangSau.Visibility = Visibility.Hidden;
            else
                btnTrangSau.Visibility = Visibility.Visible;
        }
    }
}
