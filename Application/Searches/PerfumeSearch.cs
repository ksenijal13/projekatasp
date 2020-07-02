using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class PerfumeSearch : PagedSearch
    {
        public string Name { get; set; }
        public int GenderId { get; set; }
        public int FragranceTypeId { get; set; }
        public bool PriceAsc { get; set; }
    }
}
