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
    public class EfUpdateCartQuantity : IUpdateCartQuantity
    {
        private PerfumeContext _context;
        private UpdateCartQuantityValidator _validator;
        public EfUpdateCartQuantity(PerfumeContext context, UpdateCartQuantityValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 14;

        public string Name => "Updated cart quantity";

        public void Execute(CartDto request)
        {
            _validator.ValidateAndThrow(request);

            var cart = _context.Carts.Find(request.Id);
            cart.Quantity = request.Quantity;
            cart.ModifiedAt = DateTime.Now;
            if(request.Quantity < 1)
            {
                cart.IsDeleted = true;
                cart.DeletedAt = DateTime.Now;
                cart.IsActive = false;
            }
            _context.SaveChanges();

        }
    }
}
