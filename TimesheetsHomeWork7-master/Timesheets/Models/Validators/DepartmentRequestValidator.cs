using FluentValidation;
using Timesheets.Models.Request;

namespace Timesheets.Models.Validators
{
    public class DepartmentRequestValidator : AbstractValidator<DepartmentRequest>
    {
        public DepartmentRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .Length(1, 1000)
                .ToString();

        }
    }
}
