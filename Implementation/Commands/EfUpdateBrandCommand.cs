using Application.Commands;
using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateBrandCommand : IUpdateBrandCommand
    {
        private PerfumeContext _context;
        private UpdateBrandValidator _validator;
        public EfUpdateBrandCommand(PerfumeContext context, UpdateBrandValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;

        public string Name => "Updating brand";

        public void Execute(BrandDto request)
        {
            _validator.ValidateAndThrow(request);
            var brand = _context.Brands.Find(request.Id);
            if(request.Name != null)
            {
                brand.Name = request.Name;
            }
            if(request.IsActive != null)
            {
                brand.IsActive = (bool) request.IsActive;
            }
            if(request.Description != null)
            {
                brand.Description = request.Description;
            }
            brand.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
