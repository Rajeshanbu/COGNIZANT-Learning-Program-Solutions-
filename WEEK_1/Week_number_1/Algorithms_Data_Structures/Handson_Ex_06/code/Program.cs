using System;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(int id, string title, string author)
    {
        BookId = id;
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"ID: {BookId}, Title: {Title}, Author: {Author}";
    }
}

class LibrarySystem
{
    // Linear Search by title
    public static Book LinearSearch(Book[] books, string title)
    {
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return book;
        }
        return null;
    }

    // Binary Search by title (Assumes books are sorted by title)
    public static Book BinarySearch(Book[] books, string title)
    {
        int low = 0, high = books.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int cmp = string.Compare(books[mid].Title, title, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0) return books[mid];
            else if (cmp < 0) low = mid + 1;
            else high = mid - 1;
        }
        return null;
    }

    public static void Main(string[] args)
    {
        Book[] books = {
            new Book(101, "C Programming", "Dennis Ritchie"),
            new Book(102, "Java Basics", "James Gosling"),
            new Book(103, "Python 101", "Guido van Rossum"),
            new Book(104, "Data Structures", "Mark Allen")
        };

        // Sort books by title for binary search
        Array.Sort(books, (a, b) => a.Title.CompareTo(b.Title));

        Console.WriteLine("Searching for 'Java Basics'...");

        // Linear Search
        var result1 = LinearSearch(books, "Java Basics");
        Console.WriteLine(result1 != null ? "[Linear] Found: " + result1 : "[Linear] Not found");

        // Binary Search
        var result2 = BinarySearch(books, "Java Basics");
        Console.WriteLine(result2 != null ? "[Binary] Found: " + result2 : "[Binary] Not found");
    }
}
