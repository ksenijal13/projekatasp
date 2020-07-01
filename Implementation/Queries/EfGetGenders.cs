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
    public class EfGetGenders : IGetGenders
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;

        public EfGetGenders(PerfumeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public int Id => 35;

        public string Name => "read genders";

        public PagedResponse<GenderDto> Execute(GenderSearch search)
        {
            var query = _context.Genders.AsQueryable();
                 
            return query.MakePaged<GenderDto, Gender>(search, _mapper);
        }
    }
}
