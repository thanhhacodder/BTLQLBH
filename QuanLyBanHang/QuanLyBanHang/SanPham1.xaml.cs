using Microsoft.Win32;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SanPham1.xaml
    /// </summary>
    public partial class SanPham1 : Window
    {
        QLBHEntities db;
        public string maNhanVien { get; set; }
        int _trangHienTai = 1, _soLuongSanPhamTrenMotTrang = 5, _tongSoTrang;
        public SanPham1()
        {
            InitializeComponent();

            db = new QLBHEntities();

            try
            {
                
                PhanTrangSanPham();
                this.listView2.ItemsSource = GetDanhSachSanPham();
                this.listView3.ItemsSource = GetDanhSachSanPham();

                this.cbbLSP.ItemsSource = db.LoaiSanPhams.ToList();
                this.cbbNSX.ItemsSource = db.NhaSanXuats.ToList();
                this.cbbSPTL.ItemsSource = db.LoaiSanPhams.ToList();
            }
            catch (Exception) { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            PhanTrangSanPham();            
            this.listView2.ItemsSource = GetDanhSachSanPham();
            this.listView3.ItemsSource = GetDanhSachSanPham();
        }

        bool KiemTraDuLieuSua()
        {
            int a;
            if (int.TryParse(txtTenSanPham.Text, out a))
            {
                MessageBox.Show("Tên sản phẩm là chuỗi.");
                txtTenSanPham.Clear();
                txtTenSanPham.Focus();

                return false;
            }

            if (txtTenSanPham.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được để trống.");
                txtTenSanPham.Focus();

                return false;
            }

            if (txtSuaGiaNhap.Text == "")
            {
                MessageBox.Show("Giá nhập không được để trống.");
                txtSuaGiaNhap.Focus();

                return false;
            }

            int b;
            if (!int.TryParse(txtSuaGiaNhap.Text, out b))
            {
                MessageBox.Show("Giá nhập là số nguyên.");
                txtSuaGiaNhap.Clear();
                txtSuaGiaNhap.Focus();

                return false;
            }

            if (txtSuaGiaBan.Text == "")
            {
                MessageBox.Show("Giá bán không được để trống.");
                txtSuaGiaBan.Focus();

                return false;
            }

            int c;
            if (!int.TryParse(txtSuaGiaBan.Text, out c))
            {
                MessageBox.Show("Giá bán là số nguyên.");
                txtSuaGiaBan.Clear();
                txtSuaGiaBan.Focus();

                return false;
            }

            if (txtSuaSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng không được để trống.");
                txtSuaSoLuong.Focus();

                return false;
            }

            int d;
            if (!int.TryParse(txtSuaSoLuong.Text, out d))
            {
                MessageBox.Show("Số lượng là số nguyên.");
                txtSuaSoLuong.Clear();
                txtSuaSoLuong.Focus();

                return false;
            }

            
            

            if (cbbTinhhTrang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tình trạng sản phẩm.");
                cbbTinhhTrang.Focus();

                return false;
            }



            return true;
        }

        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (listView3.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong danh sách bạn cần cập nhật.");
                return;
            }

            if (!KiemTraDuLieuSua())
                return;

            try
            {
                var item = listView3.SelectedItem as SanPham;
                var sp = db.SanPhams.Where(s => s.MaSanPham == item.MaSanPham).Single();

                if (sp != null)
                {
                    sp.TenSanPham = txtTenSanPham.Text;
                    sp.LoaiSanPham = int.Parse(cbbLoaiSanPham.SelectedValue.ToString());
                    if(!string.IsNullOrEmpty(txtURLCapNhat.Text))
                        sp.HinhAnh = File.ReadAllBytes(txtURLCapNhat.Text);
                    sp.NhaSanXuat = int.Parse(cbbNhaSanXuat.SelectedValue.ToString());
                    sp.GiaNhap = int.Parse(txtSuaGiaNhap.Text);

                    sp.GiaBan = int.Parse(txtSuaGiaBan.Text);
                    sp.SoLuong = int.Parse(txtSuaSoLuong.Text);
                    sp.MoTa = txtSuaMoTa.Text;
                    

                    sp.NhanVienNhapHang = cbbNhanVien.SelectedValue.ToString();

                    if (cbbItemCH.IsSelected)
                        sp.TinhTrang = true; //true còn hàng, false hết hàng
                    else if (cbbItemHH.IsSelected)
                        sp.TinhTrang = false;

                    db.SaveChanges();
                }

                this.Window_Loaded(sender, e);

                MessageBox.Show("Cập nhật sản phẩm thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                txtURLCapNhat.Text = "";
                cbbLoaiSanPham.SelectedIndex = -1;
                cbbNhaSanXuat.SelectedIndex = -1;
                cbbNhanVien.SelectedIndex = -1;
                cbbTinhhTrang.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void BtnXoaSP_Click(object sender, RoutedEventArgs e)
        {
            if (listView2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong danh sách bạn cần xóa.");
                return;
            }

            try
            {
                var listSP = new List<SanPham>();

                foreach (var item in listView2.SelectedItems)
                {
                    if (item != null)
                    {
                        var spViewModel = item as SanPhamViewModel;
                        var sp = db.SanPhams.SingleOrDefault(s => s.MaSanPham == spViewModel.MaSanPham);
                        if (sp == null)
                            continue;

                        if (db.ChiTietHoaDons.Where(h => h.MaSP == sp.MaSanPham).Count() != 0)
                        {
                            string mesage = "Sản phẩm '" + sp.TenSanPham.ToString() + "' trong danh sách bạn chọn, còn hóa đơn đang xử lý. Không thể xóa !";
                            MessageBox.Show(mesage);
                            return;
                        }
                        listSP.Add(sp);
                    }
                }

                if (listSP != null && listSP.Count > 0)
                {
                    db.SanPhams.RemoveRange(listSP);
                    db.SaveChanges();
                }

                this.Window_Loaded(sender, e);

                MessageBox.Show("Xóa sản phẩm thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Xóa sản phẩm thất bại !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        bool KiemTraDuLieuThem()
        {
            int a;
            if (int.TryParse(txtTenSP.Text, out a))
            {
                MessageBox.Show("Tên sản phẩm là chuỗi.");
                txtTenSP.Clear();
                txtTenSP.Focus();

                return false;
            }

            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được để trống.");
                txtTenSP.Focus();

                return false;
            }

            if (cbbLSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm !");
                return false;
            }

            if (cbbNSX.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất !");
                return false;
            }

            if (txtGiaNhap.Text == "")
            {
                MessageBox.Show("Giá nhập không được để trống.");
                txtGiaNhap.Focus();

                return false;
            }

            int b;
            if (!int.TryParse(txtGiaNhap.Text, out b))
            {
                MessageBox.Show("Giá nhập là số nguyên.");
                txtGiaNhap.Clear();
                txtGiaNhap.Focus();

                return false;
            }

            if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Giá bán không được để trống.");
                txtGiaBan.Focus();

                return false;
            }

            int c;
            if (!int.TryParse(txtGiaBan.Text, out c))
            {
                MessageBox.Show("Giá bán là số nguyên.");
                txtGiaBan.Clear();
                txtGiaBan.Focus();

                return false;
            }

            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng không được để trống.");
                txtSoLuong.Focus();

                return false;
            }

            int d;
            if (!int.TryParse(txtSoLuong.Text, out d))
            {
                MessageBox.Show("Số lượng là số nguyên.");
                txtSoLuong.Clear();
                txtSoLuong.Focus();

                return false;
            }

            
            

            if (datePicker.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ngày nhập.");
                datePicker.Focus();

                return false;
            }

            DateTime date;
            if (datePicker.Text != "" && !DateTime.TryParse(datePicker.Text, out date))
            {
                MessageBox.Show("Ngày nhập không đúng định dạng. Ví dụ: dd/MM/yyyy.");
                datePicker.Focus();

                return false;
            }

            if (datePicker.Text != "" && DateTime.Parse(datePicker.Text).AddDays(1) < DateTime.Now)
            {
                MessageBox.Show("Ngày nhập không thể nhỏ hơn ngày hiện tại.");
                datePicker.Focus();

                return false;
            }

            if (txtURL.Text == "")
            {
                MessageBox.Show("Vui lòng thêm một ảnh của sản phẩm");
                btnBrowse.Focus();

                return false;
            }

            return true;
        }

        private void BtnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTraDuLieuThem())
            {
                return;
            }

            try
            {
                var sp = new SanPham();
                sp.TenSanPham = txtTenSP.Text;
                sp.LoaiSanPham = int.Parse(cbbLSP.SelectedValue.ToString());
                sp.NhaSanXuat = int.Parse(cbbNSX.SelectedValue.ToString());
                sp.GiaNhap = int.Parse(txtGiaNhap.Text);
                sp.GiaBan = int.Parse(txtGiaBan.Text);
                sp.SoLuong = int.Parse(txtSoLuong.Text);
                sp.MoTa = txtMoTa.Text;
                

                sp.NgayNhap = DateTime.Parse(datePicker.Text);
                sp.NhanVienNhapHang = this.maNhanVien;
                sp.TinhTrang = true; //true còn hàng, false hết hàng
                sp.HinhAnh = File.ReadAllBytes(txtURL.Text);


                db.SanPhams.Add(sp);
                db.SaveChanges();

                MessageBox.Show("Thêm mới sản phẩm thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                txtTenSP.Clear();
                cbbLSP.Text = "";
                cbbNSX.Text = "";
                txtGiaNhap.Clear();
                txtGiaBan.Clear();
                txtSoLuong.Clear();
                txtMoTa.Clear();
                
                datePicker.Text = "";
                txtURL.Text = "";

                this.Window_Loaded(sender, e);


            }
            catch (Exception)
            {
                MessageBox.Show("Thêm mới sản phẩm thất bại !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void BtnXemTatCa_Click(object sender, RoutedEventArgs e)
        {
            cbbSPTL.SelectedValue = null;
            _trangHienTai = 1;
            PhanTrangSanPham();
        }

        private void CbbSPTL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbSPTL.SelectedValue.ToString() != "" && cbbSPTL.SelectedValue != null)
            {
                int maLoai;
                if (int.TryParse(cbbSPTL.SelectedValue.ToString(), out maLoai))
                {
                    _trangHienTai = 1;
                    maLoai = int.Parse(cbbSPTL.SelectedValue.ToString());
                    PhanTrangSanPham(maLoai);
                    //var listSPTL =  GetDanhSachSanPhamTheoLoai(maLoai);

                    //listView1.ItemsSource = listSPTL;
                }


            }

            else
                this.Window_Loaded(sender, e);
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                var itemSP = item.Content as SanPham;
                if (itemSP != null)
                {
                    cbbLoaiSanPham.ItemsSource = db.LoaiSanPhams.ToList();
                    cbbLoaiSanPham.SelectedItem = db.LoaiSanPhams.Single(l => l.MaLoai == itemSP.LoaiSanPham);

                    cbbNhaSanXuat.ItemsSource = db.NhaSanXuats.ToList();
                    cbbNhaSanXuat.SelectedItem = db.NhaSanXuats.Single(n => n.MaNSX == itemSP.NhaSanXuat);

                    cbbNhanVien.ItemsSource = db.NhanViens.ToList();
                    cbbNhanVien.SelectedItem = db.NhanViens.Single(n => n.MaNhanVien == itemSP.NhanVien.MaNhanVien);

                    if (itemSP.TinhTrang == true)
                        cbbItemCH.IsSelected = true;

                    else if (itemSP.TinhTrang == false)
                        cbbItemHH.IsSelected = true;

                    else
                    {
                        cbbItemCH.IsSelected = false;
                        cbbItemHH.IsSelected = false;
                    }
                }
            }
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                txtURL.Text = op.FileName;
            }
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

        private List<SanPhamViewModel> GetDanhSachSanPham()
        {
            var listSanpham = db.SanPhams.Select(x => new SanPhamViewModel()
            {
                ChiTietHoaDons = x.ChiTietHoaDons,
                GiaBan = x.GiaBan,
                
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
            }).OrderByDescending(x=>x.MaSanPham).ToList();

            foreach (var item in listSanpham)
            {
                item.TenLoaiSanPham = GetTenLoaiSanPham(item.LoaiSanPham.Value);
                item.TenNhaSanXuat = GetTenNhaSanXuat(item.NhaSanXuat.Value);
                item.TenTinhTrang = item.TinhTrang.Value ? "Còn hàng" : "Hết hàng";
            }

            return listSanpham;
        }

        

        private void BtnBrowseCapNhat_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                txtURLCapNhat.Text = op.FileName;
            }
        }

        private void BtnTrangTruoc_Click(object sender, RoutedEventArgs e)
        {
            _trangHienTai--;
            if (_trangHienTai > 0)
            {
                int maLoai;
                var tongSanPham = 0;
                
                if (cbbSPTL.SelectedValue != null && int.TryParse(cbbSPTL.SelectedValue.ToString(), out maLoai))
                {
                    maLoai = int.Parse(cbbSPTL.SelectedValue.ToString());
                    var listSanPham = GetDanhSachSanPhamPhanTrang(_trangHienTai, _soLuongSanPhamTrenMotTrang, out tongSanPham, maLoai);
                    this.listView1.ItemsSource = listSanPham;
                }
                else
                {
                    var listSanPham = GetDanhSachSanPhamPhanTrang(_trangHienTai, _soLuongSanPhamTrenMotTrang, out tongSanPham, null);
                    this.listView1.ItemsSource = listSanPham;
                }
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
            if(_trangHienTai <= _tongSoTrang)
            {
                int maLoai;
                var tongSanPham = 0;
                
                if (cbbSPTL.SelectedValue !=null && int.TryParse(cbbSPTL.SelectedValue.ToString(), out maLoai))
                {                   
                    maLoai = int.Parse(cbbSPTL.SelectedValue.ToString());
                    var listSanPham = GetDanhSachSanPhamPhanTrang(_trangHienTai, _soLuongSanPhamTrenMotTrang, out tongSanPham, maLoai);
                    this.listView1.ItemsSource = listSanPham;
                }
                else
                {
                    var listSanPham = GetDanhSachSanPhamPhanTrang(_trangHienTai, _soLuongSanPhamTrenMotTrang, out tongSanPham, null);
                    this.listView1.ItemsSource = listSanPham;
                }
                
            }
            else
            {
                _trangHienTai--;
            }
            AnHienPhanTrang();
        }

        private List<SanPhamViewModel> GetDanhSachSanPhamPhanTrang(
            int trangHienTai,
            int sanPhamTrenMotTrang,
            out int tongSanPham,
            int? idMaLoaiSP)
        {
           
            if (!idMaLoaiSP.HasValue)
            {
                var listSanpham = db.SanPhams
                                .Select(x => new SanPhamViewModel()
                                {
                                    ChiTietHoaDons = x.ChiTietHoaDons,
                                    GiaBan = x.GiaBan,
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
                                })
                            .OrderByDescending(x => x.MaSanPham)
                            .Skip((trangHienTai - 1) * sanPhamTrenMotTrang) // lay tu vi tri so 0
                            .Take(sanPhamTrenMotTrang) // lay 5 san pham
                            .ToList();

                tongSanPham = db.SanPhams.Count(); // lay tong san pham
                foreach (var item in listSanpham)
                {
                    item.TenLoaiSanPham = GetTenLoaiSanPham(item.LoaiSanPham.Value);
                    item.TenNhaSanXuat = GetTenNhaSanXuat(item.NhaSanXuat.Value);
                    item.TenTinhTrang = item.TinhTrang.Value ? "Còn hàng" : "Hết hàng";
                }

                return listSanpham.ToList();
            }
            else
            {
                var listSanpham = db.SanPhams
                .Where(p=>p.LoaiSanPham == idMaLoaiSP.Value)
                .Select(x => new SanPhamViewModel()
                {
                    ChiTietHoaDons = x.ChiTietHoaDons,
                    GiaBan = x.GiaBan,

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
                })
            .OrderByDescending(x => x.MaSanPham)
            .Skip((trangHienTai - 1) * sanPhamTrenMotTrang)
            .Take(sanPhamTrenMotTrang)
            .ToList();

                tongSanPham = db.SanPhams
                .Where(p => p.LoaiSanPham == idMaLoaiSP.Value).Count();
                foreach (var item in listSanpham)
                {
                    item.TenLoaiSanPham = GetTenLoaiSanPham(item.LoaiSanPham.Value);
                    item.TenNhaSanXuat = GetTenNhaSanXuat(item.NhaSanXuat.Value);
                    item.TenTinhTrang = item.TinhTrang.Value ? "Còn hàng" : "Hết hàng";
                }

                return listSanpham.ToList();
            }
            
        }

        

        private void PhanTrangSanPham()
        {
            var tongSanPham = 0;
            var listSanPham = GetDanhSachSanPhamPhanTrang(_trangHienTai, _soLuongSanPhamTrenMotTrang, out tongSanPham, null);
            _tongSoTrang = tongSanPham / _soLuongSanPhamTrenMotTrang;
            if (tongSanPham % _soLuongSanPhamTrenMotTrang > 0)
            {
                _tongSoTrang++;
            }

            this.listView1.ItemsSource = listSanPham;
            AnHienPhanTrang();
        }

        private void txtSuaMoTa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhanTrangSanPham(int idMaLoai)
        {
            var tongSanPham = 0;
            var listSanPham = GetDanhSachSanPhamPhanTrang(_trangHienTai, _soLuongSanPhamTrenMotTrang, out tongSanPham, idMaLoai);
            _tongSoTrang = tongSanPham / _soLuongSanPhamTrenMotTrang;
            if (tongSanPham % _soLuongSanPhamTrenMotTrang > 0)
            {
                _tongSoTrang++;
            }

            this.listView1.ItemsSource = listSanPham;
            AnHienPhanTrang();
        }

        private void AnHienPhanTrang()
        {
            if(_tongSoTrang == 0)
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
