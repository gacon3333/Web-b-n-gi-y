using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
     
        public string? Ten { get; set; }
        public int? TrangThai { get; set; }
        public string? MoTa { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
