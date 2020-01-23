using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.PL.Validators
{
    public class MemmberValidators : AbstractValidator<Memmber>
    {
        public MemmberValidators()
        {
            RuleFor(m => m.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty.`")
                .Length(2, 50)
                .WithMessage("{PropertyName} must be between 2~50 characters.")
                .Must(BeAValidName);

            RuleFor(m => m.Credit)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please enter valid {PropertyName}.")
                .GreaterThanOrEqualTo(0);
        }

        protected bool BeAValidName(string name)
        {
            name = name
                .Replace(" ", "")
                .Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
