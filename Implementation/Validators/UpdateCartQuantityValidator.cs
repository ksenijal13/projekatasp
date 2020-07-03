using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateCartQuantityValidator : AbstractValidator<CartDto>
    {
        public UpdateCartQuantityValidator(PerfumeContext context)
        {
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("You must enter quantity")
                .GreaterThan(-1).WithMessage("Quantity cant be less than zero.");
            RuleFor(x => x.PerfumeId).NotEmpty()
                  .Must(x => context.Carts.Any(c => c.PerfumeId == x)).WithMessage("This perfume doesn't exist in your cart.");
        }
    }
}
