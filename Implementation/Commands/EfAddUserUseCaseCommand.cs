using Application.Commands;
using Application.DataTransfer;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfAddUserUseCaseCommand : IAddUserUseCaseCommand
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;
        public EfAddUserUseCaseCommand(PerfumeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 10;

        public string Name => "Add new allowed usu case for user";

        public void Execute(UserUseCaseDto request)
        {
            var userUserCase = _mapper.Map<UserUseCase>(request);
            _context.UserUseCases.Add(userUserCase);
            _context.SaveChanges();
        }
    }
}
