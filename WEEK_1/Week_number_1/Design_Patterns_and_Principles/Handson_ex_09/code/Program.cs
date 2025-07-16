using System;

// Step 2: Command Interface
public interface ICommand
{
    void Execute();
}

// Step 5: Receiver Class
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

// Step 3: Concrete Commands

public class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}

public class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }
}

// Step 4: Invoker Class

public class RemoteControl
{
    private ICommand? command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressButton()
    {
        if (command != null)
        {
            command.Execute();
        }
        else
        {
            Console.WriteLine("No command set.");
        }
    }
}

// Step 6: Test Class

class Program
{
    static void Main(string[] args)
    {
        Light livingRoomLight = new Light();

        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        RemoteControl remote = new RemoteControl();

        Console.WriteLine("Pressing ON button:");
        remote.SetCommand(lightOn);
        remote.PressButton();

        Console.WriteLine("\nPressing OFF button:");
        remote.SetCommand(lightOff);
        remote.PressButton();
    }
}
