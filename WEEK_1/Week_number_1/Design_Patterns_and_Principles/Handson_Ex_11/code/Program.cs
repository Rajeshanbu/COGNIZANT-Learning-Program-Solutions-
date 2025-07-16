using System;

// Step 1 & 2: Repository Interface
public interface ICustomerRepository
{
    string FindCustomerById(int id);
}

// Step 3: Concrete Repository
public class CustomerRepositoryImpl : ICustomerRepository
{
    public string FindCustomerById(int id)
    {
        // Simulating DB lookup
        return id switch
        {
            1 => "Rajesh - Chennai",
            2 => "Anu - Coimbatore",
            _ => "Customer not found"
        };
    }
}

// Step 4: Service Class
public class CustomerService
{
    private readonly ICustomerRepository repository;

    // Step 5: Constructor Injection
    public CustomerService(ICustomerRepository repository)
    {
        this.repository = repository;
    }

    public void GetCustomerDetails(int id)
    {
        string customer = repository.FindCustomerById(id);
        Console.WriteLine($"Customer Details: {customer}");
    }
}

// Step 6: Test Class
class Program
{
    static void Main(string[] args)
    {
        ICustomerRepository repo = new CustomerRepositoryImpl(); // Dependency
        CustomerService service = new CustomerService(repo);     // Injected

        Console.WriteLine("Looking up customer ID 1:");
        service.GetCustomerDetails(1);

        Console.WriteLine("\nLooking up customer ID 3:");
        service.GetCustomerDetails(3);
    }
}
