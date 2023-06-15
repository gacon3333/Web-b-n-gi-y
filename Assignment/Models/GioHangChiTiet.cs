using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class GioHangChiTiet
    {
        //[Serializable]
        public Guid Id { get; set; }
        public Guid IdChiTietSp { get; set; }
        public Guid UserId { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public int TrangThai { get; set; }

        public virtual ChiTietSp IdChiTietSpNavigation { get; set; }
        public virtual GioHang User { get; set; }
    }
}
