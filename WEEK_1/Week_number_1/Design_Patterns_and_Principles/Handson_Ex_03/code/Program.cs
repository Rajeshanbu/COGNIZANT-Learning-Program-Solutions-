using System;

// Product class
public class Computer
{
    public string CPU { get; }
    public string RAM { get; }
    public string Storage { get; }
    public string GraphicsCard { get; }

    // Private constructor
    private Computer(Builder builder)
    {
        CPU = builder.CPU;
        RAM = builder.RAM;
        Storage = builder.Storage;
        GraphicsCard = builder.GraphicsCard;
    }

    // Display method
    public void ShowConfig()
    {
        Console.WriteLine("Computer Configuration:");
        Console.WriteLine($"CPU: {CPU}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Storage: {Storage}");
        Console.WriteLine($"Graphics Card: {GraphicsCard}");
    }

    // Static nested Builder class
    public class Builder
    {
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }
        public string GraphicsCard { get; private set; }

        public Builder SetCPU(string cpu)
        {
            CPU = cpu;
            return this;
        }

        public Builder SetRAM(string ram)
        {
            RAM = ram;
            return this;
        }

        public Builder SetStorage(string storage)
        {
            Storage = storage;
            return this;
        }

        public Builder SetGraphicsCard(string graphicsCard)
        {
            GraphicsCard = graphicsCard;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }
}

// Test class
class Program
{
    static void Main(string[] args)
    {
        // Gaming PC
        Computer gamingPC = new Computer.Builder()
            .SetCPU("Intel Core i9")
            .SetRAM("32GB")
            .SetStorage("1TB SSD")
            .SetGraphicsCard("NVIDIA RTX 4080")
            .Build();

        gamingPC.ShowConfig();

        Console.WriteLine();

        // Office PC
        Computer officePC = new Computer.Builder()
            .SetCPU("Intel Core i5")
            .SetRAM("8GB")
            .SetStorage("512GB SSD")
            .Build();

        officePC.ShowConfig();
    }
}
