using System;
using System.Net.Mail;
using FluentValidation;

namespace Doco.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.User).NotEmpty();
            RuleFor(x => x.User.Name).NotEmpty();
            RuleFor(x => x.User.Email).NotEmpty()
                .Must((s, m) =>
                {
                    try
                    {
                        var mail = new MailAddress(m).Address;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                    return true;
                })
                .WithMessage("The email is not valid");
        }
    }
}