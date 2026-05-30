using System;
using System.Collections.Generic;
using System.Text;
using UserAuthenticationSystem;

namespace UserAuthenticationSystem;

public interface IUserRepository
{
    public void SaveUser(User user, string hashedPassword);
}

public class UserRepository : IUserRepository
{
    public void SaveUser(User user, string hashedPassword)
    {
        File.AppendAllText(
        "users.txt",
        $"{user.Username},{hashedPassword},{user.Email}\n");
    }
}
