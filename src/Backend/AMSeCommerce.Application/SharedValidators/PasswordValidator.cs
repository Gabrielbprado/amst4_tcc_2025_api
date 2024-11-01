using AMSeCommerce.Exceptions;
using FluentValidation;
using FluentValidation.Validators;

namespace AMSeCommerce.Application.SharedValidators;

public class PasswordValidator<T> : PropertyValidator<T,string>
{
    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (String.IsNullOrEmpty(password))
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", ErrorMessage.PASSWORD_EMPTY);
            return false;
        }
        
        if (password.Length < 6)
        {
            context.MessageFormatter.AppendArgument("ErrorMessage", ErrorMessage.PASSWORD_INVALID);
            return false;
        }

        return true;
    }

    public override string Name { get; } = "PasswordValidator";
    
    protected override string GetDefaultMessageTemplate(string errorCode) => "{ErrorMessage}";

}