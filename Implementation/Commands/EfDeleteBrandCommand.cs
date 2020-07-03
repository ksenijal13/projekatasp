using Application.Commands;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteBrandCommand : IDeleteBrandCommand
    {
        private PerfumeContext _context;
        public int Id => 5;
        public EfDeleteBrandCommand(PerfumeContext context)
        {
            _context = context;
        }
        public string Name => "Deleting Brand";

        public void Execute(int request)
        {
            var brand = _context.Brands.Find(request);
            if(brand == null)
            {
                throw new EntityNotFoundException(request, typeof(Brand));
            }
            brand.DeletedAt = DateTime.Now;
            brand.IsDeleted = true;
            brand.IsActive = false;

            var perfumes = _context.Perfumes.Where(x => x.BrandId == brand.Id).ToList();
            foreach(var perfume in perfumes)
            {
                perfume.IsDeleted = true;
                perfume.IsActive = false;
                perfume.DeletedAt = DateTime.Now;
            }
            _context.SaveChanges();
        }
    }
}
