using System;

// Step 2: Target Interface
public interface IPaymentProcessor
{
    void ProcessPayment(string amount);
}

// Step 3: Adaptee Classes (Existing Payment Gateways)

public class PayPalGateway
{
    public void MakePayment(string amount)
    {
        Console.WriteLine($"PayPal processing payment of {amount}");
    }
}

public class StripeGateway
{
    public void SendPayment(string amount)
    {
        Console.WriteLine($"Stripe processing payment of {amount}");
    }
}

public class RazorpayGateway
{
    public void PayNow(string amount)
    {
        Console.WriteLine($"Razorpay processing payment of {amount}");
    }
}

// Step 4: Adapter Classes (One per gateway)

public class PayPalAdapter : IPaymentProcessor
{
    private readonly PayPalGateway _paypal;

    public PayPalAdapter(PayPalGateway paypal)
    {
        _paypal = paypal;
    }

    public void ProcessPayment(string amount)
    {
        _paypal.MakePayment(amount);
    }
}

public class StripeAdapter : IPaymentProcessor
{
    private readonly StripeGateway _stripe;

    public StripeAdapter(StripeGateway stripe)
    {
        _stripe = stripe;
    }

    public void ProcessPayment(string amount)
    {
        _stripe.SendPayment(amount);
    }
}

public class RazorpayAdapter : IPaymentProcessor
{
    private readonly RazorpayGateway _razorpay;

    public RazorpayAdapter(RazorpayGateway razorpay)
    {
        _razorpay = razorpay;
    }

    public void ProcessPayment(string amount)
    {
        _razorpay.PayNow(amount);
    }
}

// Step 5: Test Class
class Program
{
    static void Main(string[] args)
    {
        // Using PayPal
        IPaymentProcessor paypalProcessor = new PayPalAdapter(new PayPalGateway());
        paypalProcessor.ProcessPayment("₹1000");

        // Using Stripe
        IPaymentProcessor stripeProcessor = new StripeAdapter(new StripeGateway());
        stripeProcessor.ProcessPayment("₹2000");

        // Using Razorpay
        IPaymentProcessor razorpayProcessor = new RazorpayAdapter(new RazorpayGateway());
        razorpayProcessor.ProcessPayment("₹1500");
    }
}
