using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationSystem;

public interface IValidationService
{
    public ValidationResult ValidateUser(User user);
}

public class ValidationService : IValidationService
{
    public ValidationResult ValidateUser(User user)
    {
        ValidationResult result = new ValidationResult();

        if (user.Username.Length < 3)
        {
            result.Errors.Add("Username too short");
        }

        if (!user.Email.Contains("@"))
        {
            result.Errors.Add("Invalid email");
        }
        return result;
    }
}
