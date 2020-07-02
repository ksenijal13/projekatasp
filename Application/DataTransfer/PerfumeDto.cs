using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PerfumeDto
    {
        public int Id { get; set; }
        public string Fragrance { get; set; }
        public int BrandId { get; set; }
        public int FragranceTypeId { get; set; }
        public int GenderId { get; set; }
        public decimal Price { get; set; }
        public int NumberOfAvailable { get; set; }
        public int Discount { get; set; }
        public string Image { get; set; }
       public string Brand { get; set; }
        public string FragranceType { get; set; }
        public string Gender { get; set; }
        public IEnumerable<DefineScentNotes> PerfumeScentNotes { get; set; } = new List<DefineScentNotes>();
    }

    public class DefineScentNotes
    {
        public int ScentNoteId { get; set; }
        public string ScentNote { get; set; }
    }
}
