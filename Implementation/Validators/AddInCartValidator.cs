using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class AddInCartValidator : AbstractValidator<AddInCartDto>
    {
        public AddInCartValidator(PerfumeContext context)
        {
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("You must enter quantity")
                .GreaterThan(0).WithMessage("Quantity must be at least 1.");
            RuleFor(x => x.PerfumeId).NotEmpty()
                .Must(x => context.Perfumes.Any(p => p.Id == x)).WithMessage("Perfume with that id doesn't exist.");
        }
    }
}
