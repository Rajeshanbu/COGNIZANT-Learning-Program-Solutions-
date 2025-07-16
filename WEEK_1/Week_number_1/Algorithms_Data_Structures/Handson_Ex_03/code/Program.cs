using System;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double TotalPrice { get; set; }

    public Order(int id, string name, double price)
    {
        OrderId = id;
        CustomerName = name;
        TotalPrice = price;
    }

    public override string ToString()
    {
        return $"OrderID: {OrderId}, Customer: {CustomerName}, Total: ₹{TotalPrice}";
    }
}

class Program
{
    // Bubble Sort
    static void BubbleSort(Order[] orders)
    {
        int n = orders.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    var temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

    // Quick Sort
    static void QuickSort(Order[] orders, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(orders, low, high);
            QuickSort(orders, low, pi - 1);
            QuickSort(orders, pi + 1, high);
        }
    }

    static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice <= pivot)
            {
                i++;
                var temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }

        var temp2 = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = temp2;

        return i + 1;
    }

    // Display
    static void Display(string title, Order[] orders)
    {
        Console.WriteLine($"\n{title}");
        foreach (var o in orders)
            Console.WriteLine(o);
    }

    static void Main(string[] args)
    {
        Order[] orders = {
            new Order(101, "Raj", 5600),
            new Order(102, "Anu", 12000),
            new Order(103, "John", 3500),
            new Order(104, "Sara", 7800)
        };

        // Bubble Sort
        Order[] bubbleSorted = (Order[])orders.Clone();
        BubbleSort(bubbleSorted);
        Display("Bubble Sorted Orders (by TotalPrice):", bubbleSorted);

        // Quick Sort
        Order[] quickSorted = (Order[])orders.Clone();
        QuickSort(quickSorted, 0, quickSorted.Length - 1);
        Display("Quick Sorted Orders (by TotalPrice):", quickSorted);
    }
}
