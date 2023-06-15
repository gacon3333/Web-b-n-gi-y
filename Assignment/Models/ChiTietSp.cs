using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class ChiTietSp
    {
        public ChiTietSp()
        {         
            GioHangChiTiets = new HashSet<GioHangChiTiet>();
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public Guid? IdMauSac { get; set; }
        public Guid? IdKichCo { get; set; }
        public Guid? IdKieuSp { get; set; }
        public string? BaoHanh { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        public decimal? GiaNhap { get; set; }
        public decimal? GiaBan { get; set; }
        public string? LinkAnh { get; set; }
        public int? TrangThai { get; set; }
        [JsonIgnore]
        public virtual KichCo? IdKichCoNavigation { get; set; }
        public virtual MauSac? IdMauSacNavigation { get; set; }
        
        public virtual KieuSp? IdKieuSpNavigation { get; set; }
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
