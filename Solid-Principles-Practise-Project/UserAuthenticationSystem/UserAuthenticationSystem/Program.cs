using System;
using System.IO;

namespace UserAuthenticationSystem;

class Program
{
    static void Main()
    {
        UserManager manager = new UserManager();

        manager.RegisterUser(
            "john123",
            "password123",
            "john@test.com");
    }
}
