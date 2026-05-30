using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationSystem;

public interface IHashingService
{
    public string HashPassword(string password);
}

public class HashingService : IHashingService
{
    public string HashPassword(string password)
    {
        return "HASHED_" + password;
    }
}