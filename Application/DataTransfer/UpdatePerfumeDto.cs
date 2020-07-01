using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class UpdatePerfumeDto
    {
        public int? Id { get; set; }
        public bool? IsActive { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public int? NumberOfAvailable { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
