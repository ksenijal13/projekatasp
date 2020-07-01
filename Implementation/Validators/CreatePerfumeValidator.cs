using Application.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Implementation.Validators
{
    public class CreatePerfumeValidator : AbstractValidator<CreatePerfumeDto>
    {
        public CreatePerfumeValidator()
        {
            RuleFor(x => x.Fragrance)
                .NotEmpty().WithMessage("Fragrance name is required.");
            RuleFor(x => x.FragranceTypeId)
                .NotEmpty().WithMessage("FragranceType is required."); 
            RuleFor(x => x.BrandId)
                .NotEmpty().WithMessage("Brand is required."); 
            RuleFor(x => x.GenderId)
                .NotEmpty().WithMessage("Gender is required."); 
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than 0."); 
            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount can be 0 or greater.");
            RuleFor(x => x.NumberOfAvailable).NotEmpty().WithMessage("Please enter the number of available perfumes."); 

        }
    }
}
