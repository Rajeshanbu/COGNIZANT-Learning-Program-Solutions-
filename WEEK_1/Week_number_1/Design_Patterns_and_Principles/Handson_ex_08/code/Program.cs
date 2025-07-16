using System;

// Step 2: Strategy Interface
public interface IPaymentStrategy
{
    void Pay(string amount);
}

// Step 3: Concrete Strategies

public class CreditCardPayment : IPaymentStrategy
{
    private string cardNumber;

    public CreditCardPayment(string cardNumber)
    {
        this.cardNumber = cardNumber;
    }

    public void Pay(string amount)
    {
        Console.WriteLine($"Paid ₹{amount} using Credit Card: {cardNumber}");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private string email;

    public PayPalPayment(string email)
    {
        this.email = email;
    }

    public void Pay(string amount)
    {
        Console.WriteLine($"Paid ₹{amount} using PayPal account: {email}");
    }
}

// Step 4: Context Class

public class PaymentContext
{
    private IPaymentStrategy? strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void PayAmount(string amount)
    {
        if (strategy != null)
        {
            strategy.Pay(amount);
        }
        else
        {
            Console.WriteLine("Payment strategy not set.");
        }
    }
}

// Step 5: Test Class

class Program
{
    static void Main(string[] args)
    {
        PaymentContext context = new PaymentContext();

        // Using Credit Card
        context.SetStrategy(new CreditCardPayment("1234-5678-9012-3456"));
        context.PayAmount("1500");

        Console.WriteLine();

        // Using PayPal
        context.SetStrategy(new PayPalPayment("user@example.com"));
        context.PayAmount("2200");
    }
}
