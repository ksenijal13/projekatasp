using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(PerfumeContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().MaximumLength(25);

            RuleFor(x => x.LastName)
                .NotEmpty().MaximumLength(25);

            RuleFor(x => x.Username)
                .Must(x => !context.Users.Any(u => u.Username == x))
                .WithMessage("Username is already in use.")
                .NotEmpty().MinimumLength(5).MaximumLength(25);

            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(5).MaximumLength(25); 

            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress().MaximumLength(25);
            RuleFor(x => x.Address)
                .NotEmpty().MinimumLength(4);
        }
    }
}
