using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class HoaDonChiTiet
    {
        public Guid Id { get; set; }
        public Guid? IdHoaDon { get; set; }
        public Guid? IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public int? TrangThai { get; set; }
        public string? Ten { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }

        public virtual ChiTietSp? IdChiTietSpNavigation { get; set; }
        public virtual HoaDon? IdHoaDonNavigation { get; set; }
    }
}
