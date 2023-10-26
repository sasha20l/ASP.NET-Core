using FluentValidation;
using Timesheets.Models.Requels;
using Timesheets.Models.Request;

namespace Timesheets.Models.Validators
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeRequestValidator()
        {
            RuleFor(x => x.Surname)
                .NotNull()
                .Length(3, 30)
                .ToString();

            RuleFor(x => x.FirstName)
                .NotNull()
                .Length(3, 30)
                .ToString();

            RuleFor(x => x.Patronymic)
                .NotNull()
                .Length(3, 30)
                .ToString();

            RuleFor(x => x.Description)
               .NotNull()
               .Length(1, 1000)
               .ToString();

            RuleFor(x => x.Salary)
               .NotNull();
               
        }
    }
}


