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
    public class EfGetAuditLogs : IGetAuditLogs
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;

        public EfGetAuditLogs(PerfumeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public int Id => 22;

        public string Name => "Search and read audit logs";

        public PagedResponse<AuditLogDto> Execute(AuditLogSearch search)
        {
    
            var query = _context.UseCaseLogs.AsQueryable();

            if(search.UseCaseStartDate != null && search.UseCaseEndDate != null)
            {
                query = query.Where(x => (x.Date >= search.UseCaseStartDate) && (x.Date <= search.UseCaseEndDate));
            }
            else if(search.UseCaseStartDate != null)
            {
                query = query.Where(x => x.Date >= search.UseCaseStartDate);
            }
            else if( search.UseCaseEndDate != null)
            {
                query = query.Where(x => x.Date <= search.UseCaseEndDate);
            }
            if (!string.IsNullOrEmpty(search.NameUseCase) || !string.IsNullOrWhiteSpace(search.NameUseCase))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.NameUseCase.ToLower()));
            }
            if(!string.IsNullOrEmpty(search.User) || !string.IsNullOrWhiteSpace(search.User))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.User.ToLower()));
        
            }
            
            return query.MakePaged<AuditLogDto, UseCaseLog>(search, _mapper);
        }
    }
}
