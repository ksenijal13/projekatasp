using Application.Commands;
using Application.DataTransfer;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreatePerfumeCommand : ICreatePerfumeCommand
    {
        private readonly IMapper _mapper;
        private PerfumeContext _context;
        private CreatePerfumeValidator _validator;
        public EfCreatePerfumeCommand(IMapper mapper, PerfumeContext context, CreatePerfumeValidator validator)
        {
            _mapper = mapper;
            _context = context;
            _validator = validator;
        }
        public int Id => 2;

        public string Name => "Creating perfume";

        public void Execute(CreatePerfumeDto request)
        {
            _validator.ValidateAndThrow(request);
    
            var perfume = _mapper.Map<Perfume>(request);
            _context.Perfumes.Add(perfume);
            _context.SaveChanges();
        }
    }
}
