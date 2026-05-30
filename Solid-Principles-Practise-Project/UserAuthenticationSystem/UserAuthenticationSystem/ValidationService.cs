using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationSystem;

public interface IValidationService
{
    public bool ValidateUser(User user);
}

public class ValidationService : IValidationService
{
    public bool ValidateUser(User user)
    {
        if (user.Username.Length < 3)
        {
            Console.WriteLine("Username too short");
            return false;
        }

        if (!user.Email.Contains("@"))
        {
            Console.WriteLine("Invalid email");
            return false;
        }
        return true;
    }
}
