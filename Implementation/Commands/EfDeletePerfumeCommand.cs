using Application.Commands;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeletePerfumeCommand : IDeletePerfumeCommand
    {
        private PerfumeContext _context;
        public EfDeletePerfumeCommand(PerfumeContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Deleting perfume";

        public void Execute(int id)
        {
            var perfume = _context.Perfumes.Find(id);
            if(perfume == null)
            {
                throw new  KeyNotFoundException();
            }
            perfume.DeletedAt = DateTime.Now;
            perfume.IsDeleted = true;
            perfume.IsActive = false;
            _context.SaveChanges();
        }
    }
}
