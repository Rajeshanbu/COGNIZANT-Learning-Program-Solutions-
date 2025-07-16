using System;

public class Logger
{
    // Marked as nullable to avoid CS8618 warning
    private static Logger? instance;

    // Lock object for thread safety
    private static readonly object lockObj = new object();

    // Private constructor to prevent external instantiation
    private Logger() { }

    // Public method to get the Singleton instance
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                    instance = new Logger();
            }
        }
        return instance;
    }

    // Logging method
    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("First log message");
        logger2.Log("Second log message");

        Console.WriteLine("Are both loggers the same? " + (logger1 == logger2));
    }
}
