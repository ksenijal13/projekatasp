using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public bool Delivered { get; set; }
        public bool Shiped { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual User User { get; set; }

    }
}
