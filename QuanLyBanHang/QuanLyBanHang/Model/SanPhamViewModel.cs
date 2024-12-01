using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Model
{
    public class SanPhamViewModel : SanPham
    {
        public string TenLoaiSanPham { get; set; }

        public string TenNhaSanXuat { get; set; }

        public string TenTinhTrang { get; set; }
    }
}
