using FluentValidation;
using Sat.Recruitment.Api.Dto;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sat.Recruitment.Api.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull(). WithMessage("The name is required");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("The email is required");
            RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage("The address is required");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("The phone is required");
        }

        public static bool IsValid(CreateUserDto user, out string errors)
        {
            var validator = new UserValidator();
            var result = validator.Validate(user);

            errors = "";

            if (!result.IsValid) {
                errors = string.Join(",", result.Errors);
            }

            return result.IsValid;
        }
    }
}
