using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationSystem;

public interface IAuthorisationService
{
    public void Login();
    public string GenerateToken();
}

public class AuthorisationService
{
    public void Login(string username)
    {
        Console.WriteLine($"{username} logged in");
    }

    public string GenerateToken()
    {
        return Guid.NewGuid().ToString();
    }
}
