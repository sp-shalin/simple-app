using System;
using System.Collections.Generic;

namespace Api.Data
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
