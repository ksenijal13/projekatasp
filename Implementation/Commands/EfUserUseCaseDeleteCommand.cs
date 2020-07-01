﻿using Application.Commands;
using Application.DataTransfer;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUserUseCaseDeleteCommand : IUserUseCaseDeleteCommand
    {
        private PerfumeContext _context;
      
        public EfUserUseCaseDeleteCommand(PerfumeContext context)
        {
            _context = context;
        }
        public int Id => 11;

        public string Name => "Delete use case for particular user";

        public void Execute(UserUseCaseDto request)
        {
            var useCase = _context.UserUseCases.Where(x => (x.UseCaseId == request.UseCaseId) && (x.UserId == request.UserId)).FirstOrDefault();
            _context.UserUseCases.Remove(useCase);
            _context.SaveChanges();
        }
    }
}
