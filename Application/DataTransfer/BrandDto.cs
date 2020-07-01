using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class BrandDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
