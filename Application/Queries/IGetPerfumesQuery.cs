using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetPerfumesQuery : IQuery<PerfumeSearch, PagedResponse<PerfumeDto>>
    {
    }
}
