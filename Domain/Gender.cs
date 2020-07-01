using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Perfume> Perfumes { get; set;  }
    }
}
