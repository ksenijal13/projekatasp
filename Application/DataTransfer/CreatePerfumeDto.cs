using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransfer
{
    public class CreatePerfumeDto
    {
        public string Fragrance { get; set; }
        public int BrandId { get; set; }
        public int FragranceTypeId { get; set; }
        public int GenderId { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int NumberOfAvailable { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public IEnumerable<int> PerfumeScentNotes { get; set; } = new List<int>();
       
    }
   
}
