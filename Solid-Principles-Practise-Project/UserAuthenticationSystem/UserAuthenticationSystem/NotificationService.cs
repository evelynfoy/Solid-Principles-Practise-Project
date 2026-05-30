using System;
using System.Collections.Generic;
using System.Text;
using UserAuthenticationSystem;

namespace UserAuthenticationSystem;

public interface INotificationService
{
    public void SendEmail(User user);
}

public class NotificationService : INotificationService
{
    public void SendEmail(User user)
    {
        Console.WriteLine($"Sending welcome email to {user.Email}");
    }
}

