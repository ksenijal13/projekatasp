using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain;
using EFDataAccess;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetFragranceTypeQuery : IGetFragranceTypes
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;

        public EfGetFragranceTypeQuery(PerfumeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public int Id => 36;

        public string Name => "reading fragrance types";

        public PagedResponse<FragranceTypeDto> Execute(FragranceSearch search)
        {
            var query = _context.FragranceTypes.AsQueryable();

            return query.MakePaged<FragranceTypeDto, FragranceType>(search, _mapper);
        }
    }
}
