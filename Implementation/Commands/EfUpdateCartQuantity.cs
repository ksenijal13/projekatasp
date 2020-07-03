using Application;
using Application.Commands;
using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateCartQuantity : IUpdateCartQuantity
    {
        private PerfumeContext _context;
        private UpdateCartQuantityValidator _validator;
        private IApplicationActor _actor;
        public EfUpdateCartQuantity(PerfumeContext context, UpdateCartQuantityValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 14;

        public string Name => "Updated cart quantity";

        public void Execute(CartDto request)
        {
            _validator.ValidateAndThrow(request);

            int userId = _actor.Id;
           
            var cart = _context.Carts.Where(x => x.PerfumeId == (request.PerfumeId) && (x.UserId == userId)).FirstOrDefault();
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
