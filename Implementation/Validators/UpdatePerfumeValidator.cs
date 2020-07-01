using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validators
{
    public class UpdatePerfumeValidator : AbstractValidator<UpdatePerfumeDto>
    {
        public UpdatePerfumeValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount can be 0 or greater.");
            RuleFor(x => x.NumberOfAvailable).GreaterThanOrEqualTo(0).WithMessage("Number of available perfumes can be 0 or greather.");
        }
    }
}
