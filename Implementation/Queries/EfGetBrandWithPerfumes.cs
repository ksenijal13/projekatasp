using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetBrandWithPerfumes : IGetBrandWithPerfumesQuery
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;
        public EfGetBrandWithPerfumes(PerfumeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 8;

        public string Name => "Reading brand with perfumes";

        public ReadBrandPerfumesDto Execute(int search)
        {
            var brand = _context.Brands
                .Include(brand => brand.Perfumes)
                .ThenInclude(perfume => perfume.PerfumeScentNotes)
                .ThenInclude(psn => psn.ScentNote)
                .FirstOrDefault(x => x.Id == search);

            var brandDto = _mapper.Map<ReadBrandPerfumesDto>(brand);
           
            return brandDto;

        }
    }
}
