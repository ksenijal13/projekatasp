using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class AuditLogSearch : PagedSearch
    {
        public string User { get; set; }
        public string NameUseCase { get; set; }
        public DateTime? UseCaseStartDate { get; set; }
        public DateTime? UseCaseEndDate { get; set; }
    }
}
