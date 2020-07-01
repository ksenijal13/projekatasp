using Application.Commands;
using Application.DataTransfer;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateBrandCommand : ICreateBrandCommand
    {
        private PerfumeContext _context;
        private CreateBrandValidator _validator;
        private readonly IMapper _mapper;
        public EfCreateBrandCommand(PerfumeContext context, CreateBrandValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }
        public int Id => 7;

        public string Name => "Creating brand";

        public void Execute(InsertBrandDto request)
        {
            _validator.ValidateAndThrow(request);
            var brand = _mapper.Map<Brand>(request);
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
    }
}
