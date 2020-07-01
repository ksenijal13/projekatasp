using Application;
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
    public class EfGetYourCartQuery : IGetYourCartQuery
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;
        private IApplicationActor _actor;

        public int Id => 15;

        public string Name => "Read cart data";

        public EfGetYourCartQuery(PerfumeContext context, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _actor = actor;
        }

        public List<YourCartDto> Execute(int search)
        {
            int userId = _actor.Id;
            if(userId != search)
            {
               throw new UnauthorizedAccessException();
            }
            var card = _context.Carts
                .Include(c => c.Perfume).ThenInclude(p => p.Brand).Where(c => c.UserId == search && !c.IsDeleted).ToList();
            var cards = _mapper.Map<List<YourCartDto>>(card);
            return cards;
             
        }
    }
}
