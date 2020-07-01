using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ScentNote : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<PerfumeScentNote> PerfumesScentNote { get; set; }
    }
}
