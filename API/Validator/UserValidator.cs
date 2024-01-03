using Common;
using FluentValidation;

namespace API.Validator
{
    public class UserValidator : AbstractValidator<UserModel>
    {

        public UserValidator()
        {
            RuleFor(user => user.Username).NotNull().WithMessage("Username Vazio");
            RuleFor(user => user.Email).NotNull().WithMessage("Email Vazio");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Email Invalido!");
            //RuleFor(user => user.UserName).NotNull();
            RuleFor(user => user.Password).NotNull().WithMessage("digite a senha!");
            RuleFor(user => user.Password).Equal(o => o.ConfirmPassword).NotNull().WithMessage("Senhas Diferentes");
        }
    }
}
