using System;

// Step 2: Component Interface
public interface INotifier
{
    void Send(string message);
}

// Step 3: Concrete Component
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("Email Notification: " + message);
    }
}

// Step 4a: Abstract Decorator
public abstract class NotifierDecorator : INotifier
{
    protected INotifier notifier;

    public NotifierDecorator(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public virtual void Send(string message)
    {
        notifier.Send(message);
    }
}

// Step 4b: Concrete Decorators

public class SMSNotifierDecorator : NotifierDecorator
{
    public SMSNotifierDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("SMS Notification: " + message);
    }
}

public class SlackNotifierDecorator : NotifierDecorator
{
    public SlackNotifierDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("Slack Notification: " + message);
    }
}

// Step 5: Test Class
class Program
{
    static void Main(string[] args)
    {
        // Only Email Notification
        INotifier email = new EmailNotifier();
        Console.WriteLine("Single Channel:");
        email.Send("System Alert!");

        Console.WriteLine();

        // Email + SMS Notification
        INotifier emailSms = new SMSNotifierDecorator(new EmailNotifier());
        Console.WriteLine("Email + SMS:");
        emailSms.Send("Server Down!");

        Console.WriteLine();

        // Email + SMS + Slack Notification
        INotifier allChannels = new SlackNotifierDecorator(new SMSNotifierDecorator(new EmailNotifier()));
        Console.WriteLine("Email + SMS + Slack:");
        allChannels.Send("Critical Error!");
    }
}
