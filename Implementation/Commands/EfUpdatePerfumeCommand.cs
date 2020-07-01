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
    public class EfUpdatePerfumeCommand : IUpdatePerfumeCommand
    {
        private PerfumeContext _context;
        private UpdatePerfumeValidator _validator;
        public EfUpdatePerfumeCommand(PerfumeContext context, UpdatePerfumeValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "Updating perfume";

        public void Execute(UpdatePerfumeDto request)
        {
            _validator.ValidateAndThrow(request);
            var perfume = _context.Perfumes.Find(request.Id);
            if (perfume == null)
            {
                throw new KeyNotFoundException();
            }
            if (request.Image != null)
            {
                perfume.Image = request.Image;
            }
            if (request.IsActive != null)
            {
                perfume.IsActive = (bool)request.IsActive;
            }
            if (request.Price != null)
            {
                perfume.Price = (decimal)request.Price;
            }
            if (request.Discount != null)
            {
                perfume.Discount = (int) request.Discount;
            }
            if (request.NumberOfAvailable != null)
            {
                perfume.NumberOfAvailable = (int) request.NumberOfAvailable;
            }
            perfume.ModifiedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
