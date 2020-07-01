using Application.DataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetPerfumesByFragranceType : IQuery<PerfumeSearch, PagedResponse<PerfumeDto>>
    {
    }
}
