using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain;
using EFDataAccess;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetPerfumesByGender : IGetPerfumesByGender
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;

        public EfGetPerfumesByGender(PerfumeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public int Id => 33;

        public string Name => "get by gender perfumes";

        public PagedResponse<PerfumeDto> Execute(PerfumeSearch search)
        {
            var query = _context.Perfumes
                 .Include(x => x.Brand)
                 .AsQueryable();

            if(search.GenderId == 1010 || search.GenderId == 1011)
            {
                query = query.Where(x => x.GenderId == search.GenderId);
            }
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => (x.Fragrance.ToLower().Contains(search.Name.ToLower())) || (x.Brand.Name.ToLower().Contains(search.Name.ToLower())));
            }

            return query.MakePaged<PerfumeDto, Perfume>(search, _mapper);
        }
    }
}
