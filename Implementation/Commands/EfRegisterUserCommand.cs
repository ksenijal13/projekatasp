using Application.Commands;
using Application.DataTransfer;
using Application.Email;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Implementation.Commands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private RegisterUserValidator _validator;
        private PerfumeContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(RegisterUserValidator validator, PerfumeContext context, IMapper mapper, IEmailSender sender)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
            _sender = sender;

        }
        public int Id => 1;
        public string Name => "Register user";
        
        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = _mapper.Map<User>(request);
            _context.Users.Add(user);

            _context.SaveChanges();
            int id = user.Id;
            List<int> listUseCases = new List<int> { 12, 16, 13, 8, 25, 9, 15, 14, 33, 34, 35, 36};
            foreach(int useCase in listUseCases)
            {
                _context.UserUseCases.Add(new UserUseCase
                {
                    UserId = id,
                    UseCaseId = useCase
                });
            }
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfull registration!</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
