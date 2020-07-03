using Application.DataTransfer;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateBrandValidator : AbstractValidator<BrandDto>
    {
        public UpdateBrandValidator(PerfumeContext context)
        {
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Brand Name cannot have less than 1 caracter.");
            RuleFor(x => x.Id).NotEmpty().WithMessage("You must enter an id of the product you want to edit.")
                .Must(x => context.Brands.Any(u => u.Id == x)).WithMessage("Brand with that Id doesn't exist.");
           
        }
    }
}
