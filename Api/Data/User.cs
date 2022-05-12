using System;
using System.Collections.Generic;

namespace Api.Data
{
    public partial class User
    {
        public User()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
