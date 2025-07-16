using System;

// Step 1: Common Interface
public interface IDocument
{
    void Open();
}

// Step 2: Concrete Document Classes
public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening a Word Document.");
    }
}

public class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening a PDF Document.");
    }
}

public class ExcelDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening an Excel Document.");
    }
}

// Step 3: Abstract Factory
public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

// Step 4: Concrete Factories
public class WordFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

public class PdfFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

public class ExcelFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new ExcelDocument();
    }
}

// Step 5: Test Class
class Program
{
    static void Main(string[] args)
    {
        DocumentFactory wordFactory = new WordFactory();
        IDocument word = wordFactory.CreateDocument();
        word.Open();

        DocumentFactory pdfFactory = new PdfFactory();
        IDocument pdf = pdfFactory.CreateDocument();
        pdf.Open();

        DocumentFactory excelFactory = new ExcelFactory();
        IDocument excel = excelFactory.CreateDocument();
        excel.Open();
    }
}
