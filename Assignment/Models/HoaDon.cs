using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public Guid Id { get; set; }
        public string? Ma { get; set; }
        public DateTime? NgayTao { get; set; }
        public Guid? UserId { get; set; }
        public string? MoTa { get; set; }
        public int? TrangThai { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
