using FluentValidation;
using Timesheets.Models.Requels;

namespace EmployeeService.Models.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .Length(7, 255)
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .Length(5, 30);

        }
    }
}
