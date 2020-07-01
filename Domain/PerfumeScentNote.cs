using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PerfumeScentNote
    {
        public int Id { get; set; }
        public int PerfumeId { get; set; }
        public int ScentNoteId { get; set; }
        public virtual Perfume Perfume {get; set;}
        public virtual ScentNote ScentNote { get; set; }
    }
}
