using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Perfume> Perfumes { get; set; }
    }
}
