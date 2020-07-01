using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators
{
    public class CreateBrandValidator : AbstractValidator<InsertBrandDto>
    {
        public CreateBrandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name of Brand cannot be empty.")
                .MinimumLength(1).WithMessage("Name of brand must be at least one caracter long.");
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("You must write description for brand.")
               .MinimumLength(5).WithMessage("Description must be at least 5 caracters long");
        }
    }
}
