using System;
using System.IO;

namespace UserAuthenticationSystem;

class Program
{
    static void Main()
    {
        User user = new User("john123", "password123", "john@test.com");

        UserManager manager = new UserManager();

        manager.RegisterUser(user);

    }
}
