namespace ConsoleApp4.Models
{
    internal class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; }
        public int Year { get; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"Id: {Id,-20} | Title: {Title,-15} | Author: {Author,-15} | Year: {Year,-4}";
        }
    }
}
