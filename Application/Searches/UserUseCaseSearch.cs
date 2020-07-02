using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class UserUseCaseSearch : PagedSearch
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
    }
}
