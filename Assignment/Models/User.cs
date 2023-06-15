using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class User
    {
        public User()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public Guid Id { get; set; }
        public Guid? RolesId { get; set; }
     
        public string? Ten { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public string? MatKhau { get; set; }
        public string? Email { get; set; }
        public string? TaiKhoan { get; set; }
        public int? TrangThai { get; set; }

        public virtual Role? Roles { get; set; }
        public virtual GioHang? GioHang { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
