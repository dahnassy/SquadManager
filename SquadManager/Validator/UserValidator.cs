using FluentValidation;
using SquadManager.Models;

namespace SquadManager.Validator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {

        public UserValidator() {
            RuleFor(user => user.Email).NotNull().WithMessage("Email Vazio");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Email Invalido!");
            //RuleFor(user => user.UserName).NotNull();
            RuleFor(user => user.Password).NotNull().WithMessage("digite a senha!");
        }
    }
}
