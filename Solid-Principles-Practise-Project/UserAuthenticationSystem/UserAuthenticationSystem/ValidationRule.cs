using System;
using System.Collections.Generic;
using System.Text;
using UserAuthenticationSystem;

namespace UserAuthenticationSystem
{
    public interface IValidationRule
    {
        public ValidationResult Validate(User user);
    }

    public class UserNameValidationRule : IValidationRule
    {
        public ValidationResult Validate(User user)
        {
            ValidationResult result = new ValidationResult();

            if (user.Username.Length < 3)
            {
                result.Errors.Add("Username too short");
            }
            return result;
        }
    }

    public class EmailValidationRule : IValidationRule
    {
        public ValidationResult Validate(User user)
        {
            ValidationResult result = new ValidationResult();

            if (!user.Email.Contains("@"))
            {
                result.Errors.Add("Invalid email");
            }
            return result;
        }
    }
}
