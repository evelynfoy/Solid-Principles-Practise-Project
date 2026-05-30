using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationSystem;

public interface ILogger
{
    public void Log(string username);
}

public class Logger : ILogger
{

    public void Log(string message)
    {
        Console.WriteLine(message);
    }

}
