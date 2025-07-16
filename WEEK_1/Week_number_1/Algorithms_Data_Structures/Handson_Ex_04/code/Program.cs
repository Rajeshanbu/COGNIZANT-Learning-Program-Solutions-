using System;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string position, double salary)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: ₹{Salary}";
    }
}

class EmployeeManager
{
    private Employee[] employees;
    private int count = 0;

    public EmployeeManager(int size)
    {
        employees = new Employee[size];
    }

    // Add
    public void AddEmployee(Employee emp)
    {
        if (count < employees.Length)
        {
            employees[count++] = emp;
            Console.WriteLine("Employee added.");
        }
        else
        {
            Console.WriteLine("Employee array is full.");
        }
    }

    // Search
    public void SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                Console.WriteLine("Found: " + employees[i]);
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }

    // Traverse
    public void ShowAll()
    {
        Console.WriteLine("\nAll Employees:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(employees[i]);
        }
    }

    // Delete by ID
    public void DeleteEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                for (int j = i; j < count - 1; j++)
                    employees[j] = employees[j + 1];

                employees[--count] = null;
                Console.WriteLine("Employee deleted.");
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeManager manager = new EmployeeManager(5);

        manager.AddEmployee(new Employee(201, "Raj", "Developer", 50000));
        manager.AddEmployee(new Employee(202, "Anu", "Manager", 70000));
        manager.AddEmployee(new Employee(203, "Sara", "Tester", 40000));

        manager.ShowAll();

        Console.WriteLine("\nSearching ID 202:");
        manager.SearchEmployee(202);

        Console.WriteLine("\nDeleting ID 202:");
        manager.DeleteEmployee(202);

        manager.ShowAll();
    }
}
