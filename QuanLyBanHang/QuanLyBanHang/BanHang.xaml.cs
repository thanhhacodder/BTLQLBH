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
    /// Interaction logic for BanHang.xaml
    /// </summary>
    public partial class BanHang : Window
    {
        QLBHEntities db;
        public BanHang()
        {
            InitializeComponent();

            db = new QLBHEntities();

            try
            {
                lv.ItemsSource = GetDanhSachSanPham();
            }
            catch (Exception) { }

            var query2 = from nsx in db.NhaSanXuats
                         select nsx;

            cbbNSXTimKiem.SelectedValuePath = "MaNSX";
            cbbNSXTimKiem.DisplayMemberPath = "TenNSX";
            cbbNSXTimKiem.SelectedIndex = -1;
            cbbNSXTimKiem.ItemsSource = query2.ToList();

            var query4 = from l in db.LoaiSanPhams
                         select l;

            cbbLoaiTimKiem.SelectedValuePath = "MaLoai";
            cbbLoaiTimKiem.DisplayMemberPath = "TenLoai";
            cbbLoaiTimKiem.SelectedIndex = -1;
            cbbLoaiTimKiem.ItemsSource = query4.ToList();

            var query3 = from nv in db.NhanViens
                         select nv;

            cbbNVLapHoaDon.SelectedValuePath = "MaNhanVien";
            cbbNVLapHoaDon.DisplayMemberPath = "TenNhanVien";
            cbbNVLapHoaDon.SelectedIndex = -1;
            cbbNVLapHoaDon.ItemsSource = query3.ToList();
        }

        private List<SanPhamViewModel> GetDanhSachSanPham()
        {
            var listSanpham = db.SanPhams.Select(x => new SanPhamViewModel()
            {
                ChiTietHoaDons = x.ChiTietHoaDons,
                GiaBan = x.GiaBan,
                GiamGia = x.GiamGia,
                GiaNhap = x.GiaNhap,
                HinhAnh = x.HinhAnh,
                LoaiSanPham = x.LoaiSanPham,
                LoaiSanPham1 = x.LoaiSanPham1,
                MaSanPham = x.MaSanPham,
                MoTa = x.MoTa,
                NgayNhap = x.NgayNhap,
                NhanVien = x.NhanVien,
                NhanVienNhapHang = x.NhanVienNhapHang,
                NhaSanXuat = x.NhaSanXuat,
                NhaSanXuat1 = x.NhaSanXuat1,
                SoLuong = x.SoLuong,
                TenSanPham = x.TenSanPham,
                TinhTrang = x.TinhTrang
            }).OrderByDescending(x => x.MaSanPham).ToList();

            foreach (var item in listSanpham)
            {
                item.TenLoaiSanPham = GetTenLoaiSanPham(item.LoaiSanPham.Value);
                item.TenNhaSanXuat = GetTenNhaSanXuat(item.NhaSanXuat.Value);
                item.TenTinhTrang = item.TinhTrang.Value ? "Còn hàng" : "Hết hàng";
            }

            return listSanpham;
        }

        private string GetTenLoaiSanPham(int idLoaiSanPham)
        {
            var loaiSanPham = db.LoaiSanPhams.SingleOrDefault(x => x.MaLoai == idLoaiSanPham);
            if (loaiSanPham != null) return loaiSanPham.TenLoai;
            return string.Empty;
        }

        private string GetTenNhaSanXuat(int idNhaSanXuat)
        {
            var nhaSanXuat = db.NhaSanXuats.SingleOrDefault(x => x.MaNSX == idNhaSanXuat);
            if (nhaSanXuat != null) return nhaSanXuat.TenNSX;
            return string.Empty;
        }

        private bool KiemTraTinhTien()
        {
            if (string.IsNullOrEmpty(txtMaSanPham.Text))
                return false;

            if (string.IsNullOrEmpty(txtTenSanPham.Text))
                return false;

            if (string.IsNullOrEmpty(txtDonGia.Text))
                return false;

            if (string.IsNullOrEmpty(txtSoLuongMua.Text))
                return false;

            int soLuong;
            if (!int.TryParse(txtSoLuongMua.Text,out soLuong))
                return false;

            return true;
        }
        private void btnTinhTien_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTraTinhTien())
            {
                MessageBox.Show("Thông tin mua hàng chưa đủ, vui lòng kiểm tra lại !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            double tongtien = int.Parse(txtDonGia.Text) * int.Parse(txtSoLuongMua.Text);
            txtThanhTien.Text = String.Format("{0:0,0   VNĐ}", tongtien);
            dpNgayLap.SelectedDate = DateTime.Now;
        }

        private void btnTaoMoi_Click(object sender, RoutedEventArgs e)
        {
            ClearDuLieu();
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = int.Parse(cbbLoaiTimKiem.SelectedValue.ToString());
                int b = int.Parse(cbbNSXTimKiem.SelectedValue.ToString());
                var query = from sp in db.SanPhams
                            where sp.TenSanPham.Contains(txtTenSPTimKiem.Text) && (sp.NhaSanXuat == b) && (sp.LoaiSanPham == a)
                            select sp;
                lv.ItemsSource = query.ToList();
                ClearDuLieu();
            }
            catch (Exception)
            {
                MessageBox.Show("Thông tin tìm kiếm chưa có !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        bool KiemTraLapHoaDon()
        {
            bool kt = true;
            if (txtTenKhachHang.Text == "" || txtDiaChi.Text == "" || txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Thông tin khách hàng chưa đủ, vui lòng kiểm tra lại !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                kt = false;
            }
            if (txtMaSanPham.Text == "" || txtTenSanPham.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("Thông tin mua hàng chưa đủ, vui lòng kiểm tra lại !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                kt = false;
            }
            if (txtThanhTien.Text == "")
            {
                MessageBox.Show("Chưa tính tiền !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                kt = false;
            }
            if(cbbNVLapHoaDon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                kt = false;
            }
            return kt;
        }


        private void btnLapHoaDon_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTraLapHoaDon() == true)
            {
                try
                {
                    QLBHEntities entities = new QLBHEntities();

                    HoaDon hd = new HoaDon();
                    hd.TenKhachHang = txtTenKhachHang.Text;
                    hd.TongTien = int.Parse(txtSoLuongMua.Text) * int.Parse(txtDonGia.Text);
                    hd.NgayLap = dpNgayLap.SelectedDate;
                    hd.NVLapHD = cbbNVLapHoaDon.SelectedValue.ToString();
                    hd.TrangThai = "Mới tạo";
                    entities.HoaDons.Add(hd);

                    ChiTietHoaDon cthd = new ChiTietHoaDon();
                    cthd.MaHD = hd.MaHD;
                    cthd.TenKhachHang = txtTenKhachHang.Text;
                    cthd.DiaChi = txtDiaChi.Text;
                    cthd.SoDienThoai = txtSoDienThoai.Text;
                    cthd.MaSP = int.Parse(txtMaSanPham.Text);
                    cthd.SoLuong = int.Parse(txtSoLuongMua.Text);
                    cthd.DonGia = int.Parse(txtDonGia.Text);
                    cthd.ThanhTien = int.Parse(txtSoLuongMua.Text) * int.Parse(txtDonGia.Text);
                    entities.ChiTietHoaDons.Add(cthd);

                    entities.SaveChanges();

                    MessageBox.Show("Lập hóa đơn thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    ClearDuLieu();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lập hóa đơn thất bại !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        private void ClearDuLieu()
        {
            txtTenKhachHang.Clear();
            txtSoLuongMua.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
            txtTenSanPham.Clear();
            dpNgayLap.SelectedDate = null;
            cbbNVLapHoaDon.SelectedValue = null;
            txtTenKhachHang.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtMaSanPham.Clear();
            txtSoLuongMua.Clear();
            txtDonGia.Clear();
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            lv.ItemsSource = db.SanPhams.ToList();
        }
    }
}
