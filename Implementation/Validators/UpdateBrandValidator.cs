using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateBrandValidator : AbstractValidator<BrandDto>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Brand Name cannot have less than 1 caracter.");
        }
    }
}
