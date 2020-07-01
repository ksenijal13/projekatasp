using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Perfume : Entity
    {
        public string Fragrance { get; set; }
        public int BrandId { get; set; }
        public int FragranceTypeId { get; set; }
        public int GenderId { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int NumberOfAvailable { get; set; }
        public string Image { get; set; }
        public virtual Brand Brand { get; set; } 
        public virtual FragranceType FragranceType {get; set;}
        public virtual Gender Gender { get; set; }
        public virtual ICollection<PerfumeScentNote> PerfumeScentNotes { get; set; } = new HashSet<PerfumeScentNote>();
        public ICollection<Cart> PerfumesInCart { get; set; } = new HashSet<Cart>();
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
