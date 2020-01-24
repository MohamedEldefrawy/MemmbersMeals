using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmbersMeals.PL.Validators
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator()
        {
            RuleFor(m => m.Price)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("Please Enter a valid {PropertyName}");

            RuleFor(m => m.MealsDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(BeAValidDate).WithMessage("Please Enter a Valid {PropertyName}");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
