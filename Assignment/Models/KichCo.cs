using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClassLibrary1.Models
{
    public partial class KichCo
    {
        public KichCo()
        {
            ChiTietSps = new HashSet<ChiTietSp>();
        }

        public Guid Id { get; set; }
       
        public int? Size { get; set; }
        public int? TrangThai { get; set; }
    
        public virtual ICollection<ChiTietSp> ChiTietSps { get; set; }
        
    }
}
