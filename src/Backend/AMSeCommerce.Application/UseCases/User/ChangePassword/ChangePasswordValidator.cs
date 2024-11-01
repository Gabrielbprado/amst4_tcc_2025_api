using AMS_News.Communication.Request.User;
using AMSeCommerce.Application.SharedValidators;
using FluentValidation;

namespace AMSeCommerce.Application.UseCases.User.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(r => r.NewPassword).SetValidator(new PasswordValidator<RequestChangePasswordJson>());
    }
}