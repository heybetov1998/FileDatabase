using ConsoleApp4.Models;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbStore store = new();

            store.Add(new("Book1", "Auth1", 2001));
            store.AddRange(new()
            {
                new("Book2","Auth2",2002),
                new("Book3","Auth2",2010),
                new("Book4","Auth3",2009),
                new("Book5","Auth2",2005),
            });

            store.Remove("dede756b-51d3-4451-a4b7-a5db4863677e");
            store.Update("22fd6197-4e51-4b10-a1ed-983dbb4b972c");

            Console.WriteLine();
            store.ShowBook("22fd6197-4e51-4b10-a1ed-983dbb4b972c");
            Console.WriteLine();

            store.ShowAllBooks();
        }
    }
}