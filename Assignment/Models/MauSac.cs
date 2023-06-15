using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClassLibrary1.Models
{
    public partial class MauSac
    {
        public MauSac()
        {
            ChiTietSps = new HashSet<ChiTietSp>();
        }

        public Guid Id { get; set; }
     
        public string? Ten { get; set; }
        public int? TrangThai { get; set; }
      
        public virtual ICollection<ChiTietSp> ChiTietSps { get; set; }
    }
}
