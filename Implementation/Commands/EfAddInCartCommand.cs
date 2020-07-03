using Application;
using Application.Commands;
using Application.DataTransfer;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfAddInCartCommand : IAddInCartCommand
    {
        private PerfumeContext _context;
        private readonly IMapper _mapper;
        private AddInCartValidator _validator;
        private IApplicationActor _actor;
        public EfAddInCartCommand(PerfumeContext context, IMapper mapper, AddInCartValidator validator, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 12;

        public string Name => "Added in cart.";

        public void Execute(AddInCartDto request)
        {
            _validator.ValidateAndThrow(request);
            request.UserId = _actor.Id;
            var cart = _mapper.Map<Cart>(request);
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }
    }
}
