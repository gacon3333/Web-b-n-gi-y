using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class GioHang
    {
        public GioHang()
        {
            GioHangChiTiets = new HashSet<GioHangChiTiet>();
        }

        public Guid UserId { get; set; }
        public string? MoTa { get; set; }
        public int? TrangThai { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
