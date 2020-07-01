using Application.DataTransfer;
using Application.Searches;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetBrandWithPerfumesQuery : IQuery<int, ReadBrandPerfumesDto>
    {
    }
}
