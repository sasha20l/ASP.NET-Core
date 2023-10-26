using FluentValidation;
using Timesheets.Models.Requels;
using Timesheets.Models.Request;

namespace Timesheets.Models.Validators
{
    public class EmployeeTypeRequestValidator : AbstractValidator<EmployeeTypeRequest>
    {
        public EmployeeTypeRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .Length(1, 1000)
                .ToString();
        }
    }
}
