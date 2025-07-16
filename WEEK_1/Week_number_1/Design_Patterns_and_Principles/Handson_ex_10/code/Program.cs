using System;

// Step 2: Model
public class Student
{
    public string Name { get; set; }
    public string Id { get; set; }
    public string Grade { get; set; }
}

// Step 3: View
public class StudentView
{
    public void DisplayStudentDetails(string name, string id, string grade)
    {
        Console.WriteLine("\nStudent Details:");
        Console.WriteLine($"Name  : {name}");
        Console.WriteLine($"ID    : {id}");
        Console.WriteLine($"Grade : {grade}");
    }
}

// Step 4: Controller
public class StudentController
{
    private Student model;
    private StudentView view;

    public StudentController(Student model, StudentView view)
    {
        this.model = model;
        this.view = view;
    }

    public void SetStudentName(string name)
    {
        model.Name = name;
    }

    public string GetStudentName()
    {
        return model.Name;
    }

    public void SetStudentId(string id)
    {
        model.Id = id;
    }

    public string GetStudentId()
    {
        return model.Id;
    }

    public void SetStudentGrade(string grade)
    {
        model.Grade = grade;
    }

    public string GetStudentGrade()
    {
        return model.Grade;
    }

    public void UpdateView()
    {
        view.DisplayStudentDetails(model.Name, model.Id, model.Grade);
    }
}

// Step 5: Test Class
class Program
{
    static void Main(string[] args)
    {
        // Creating model, view, and controller
        Student student = new Student();
        StudentView view = new StudentView();
        StudentController controller = new StudentController(student, view);

        // Updating student details
        controller.SetStudentName("Raj Kumar");
        controller.SetStudentId("STU1024");
        controller.SetStudentGrade("A+");

        // Displaying details using view
        controller.UpdateView();

        // Updating data again
        controller.SetStudentGrade("A");
        Console.WriteLine("\nAfter grade update:");
        controller.UpdateView();
    }
}
