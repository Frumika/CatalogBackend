using Backend.Application.Common;
using Backend.Application.Common.Base;


namespace Backend.Application.Services.Sessions.Requests;

public class DemoEntranceRequest : IValidatableRequest
{
    public string Email { get; set; } = string.Empty;

    public ValidationResult Validate()
    {
        bool isEmailValid = IdentityValidator.IsValidEmail(Email);
        bool isValid = isEmailValid;

        if (!isValid)
        {
            List<string> errors = new();
            if (!isEmailValid) errors.Add("Email is not valid");
            return ValidationResult.Fail(string.Join(Environment.NewLine, errors));
        }

        return ValidationResult.Success();
    }
}