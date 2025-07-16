using System;
using System.Collections.Generic;

// Step 2: Subject Interface
public interface IStock
{
    void RegisterObserver(IObserver observer);
    void DeregisterObserver(IObserver observer);
    void NotifyObservers();
}

// Step 3: Concrete Subject
public class StockMarket : IStock
{
    private List<IObserver> observers = new List<IObserver>();
    private string stockName;
    private double stockPrice;

    public StockMarket(string stockName)
    {
        this.stockName = stockName;
    }

    public void SetPrice(double price)
    {
        Console.WriteLine($"\n{stockName} price updated to ₹{price}");
        stockPrice = price;
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void DeregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(stockName, stockPrice);
        }
    }
}

// Step 4: Observer Interface
public interface IObserver
{
    void Update(string stockName, double stockPrice);
}

// Step 5: Concrete Observers
public class MobileApp : IObserver
{
    private string name;

    public MobileApp(string name)
    {
        this.name = name;
    }

    public void Update(string stockName, double stockPrice)
    {
        Console.WriteLine($"{name} MobileApp - {stockName} is now ₹{stockPrice}");
    }
}

public class WebApp : IObserver
{
    private string name;

    public WebApp(string name)
    {
        this.name = name;
    }

    public void Update(string stockName, double stockPrice)
    {
        Console.WriteLine($"{name} WebApp - {stockName} is now ₹{stockPrice}");
    }
}

// Step 6: Test Class
class Program
{
    static void Main(string[] args)
    {
        StockMarket relianceStock = new StockMarket("RELIANCE");

        IObserver mobileUser = new MobileApp("Raj");
        IObserver webUser = new WebApp("InvestNow");

        relianceStock.RegisterObserver(mobileUser);
        relianceStock.RegisterObserver(webUser);

        relianceStock.SetPrice(2500.50);
        relianceStock.SetPrice(2550.75);

        relianceStock.DeregisterObserver(webUser);

        relianceStock.SetPrice(2600.10);
    }
}
