using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteFromCartCommand : IDeleteFromCartCommand
    {
        private PerfumeContext _context;
        public EfDeleteFromCartCommand(PerfumeContext context)
        {
            _context = context;
        }
        public int Id => 13;

        public string Name => "Deleting from cart.";

        public void Execute(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart == null)
            {
                throw new EntityNotFoundException(id, typeof(Cart));
            }
            cart.IsDeleted = true;
            cart.DeletedAt = DateTime.Now;
            cart.IsActive = false;
            _context.SaveChanges();
        }
    }
}
