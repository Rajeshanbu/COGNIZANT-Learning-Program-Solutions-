using System;

// Step 2: Subject Interface
public interface IImage
{
    void Display();
}

// Step 3: Real Subject Class
public class RealImage : IImage
{
    private string fileName;

    public RealImage(string fileName)
    {
        this.fileName = fileName;
        LoadFromRemoteServer();
    }

    private void LoadFromRemoteServer()
    {
        Console.WriteLine("Loading image from remote server: " + fileName);
    }

    public void Display()
    {
        Console.WriteLine("Displaying: " + fileName);
    }
}

// Step 4: Proxy Class
public class ProxyImage : IImage
{
    private string fileName;
    private RealImage? realImage;

    public ProxyImage(string fileName)
    {
        this.fileName = fileName;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(fileName); // Lazy load
        }
        else
        {
            Console.WriteLine("Using cached image.");
        }
        realImage.Display();
    }
}

// Step 5: Test Class
class Program
{
    static void Main(string[] args)
    {
        IImage image1 = new ProxyImage("photo1.jpg");
        IImage image2 = new ProxyImage("photo2.jpg");

        Console.WriteLine("First call to display photo1.jpg");
        image1.Display();  // Loads from server

        Console.WriteLine("\nSecond call to display photo1.jpg");
        image1.Display();  // Uses cached image

        Console.WriteLine("\nFirst call to display photo2.jpg");
        image2.Display();  // Loads from server
    }
}
