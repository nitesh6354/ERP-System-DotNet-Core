using ERP.Application.DTOs.Employee;
using FluentValidation;

namespace ERP.Application.Validators.Employee
{
    public class CreateEmployeeValidator
        : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.EmployeeCode)
                .NotEmpty().WithMessage("Employee code is required");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Valid email is required");

            RuleFor(x => x.Salary)
                .GreaterThan(0)
                .WithMessage("Salary must be greater than zero");

            RuleFor(x => x.DateOfJoining)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage("Date of joining cannot be in the future");
        }
    }
}
