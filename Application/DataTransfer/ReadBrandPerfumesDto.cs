using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class ReadBrandPerfumesDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<PerfumeDto> Perfumes { get; set; }
    }
}
