using AMS_News.Communication.Request.User;
using AMSeCommerce.Exceptions;
using FluentValidation;

namespace AMSeCommerce.Application.UseCases.User.Update;

public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
{
    public UpdateUserValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage(ErrorMessage.NAME_EMPTY);
            RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage(ErrorMessage.EMAIL_EMPTY)
            .EmailAddress()
            .WithMessage(ErrorMessage.EMAIL_INVALID);
    }
}