using Application.DataTransfer;
using Application.Queries;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetPerfumeQuery : IGetPerfume
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;
        public EfGetPerfumeQuery(PerfumeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 25;

        public string Name => "Getting one perfume";

        public PerfumeDto Execute(int search)
        {
            var perfume = _context.Perfumes
                .Include(x => x.PerfumeScentNotes).ThenInclude(x => x.ScentNote)
                .Include(x => x.Brand)
                .Include(x => x.FragranceType)
                .Include(x => x.Gender)
                .FirstOrDefault(x => x.Id == search);
                
            var onePerfume = _mapper.Map<PerfumeDto>(perfume);
            return onePerfume;
        }
    }
}
