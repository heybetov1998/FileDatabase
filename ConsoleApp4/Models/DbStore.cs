using Newtonsoft.Json;

namespace ConsoleApp4.Models
{
    internal class DbStore
    {
        private readonly string _path = @"C:\Users\heybe\OneDrive\Desktop\GitHub\ConsoleApp4\ConsoleApp4\Files\books.json";
        public DbStore()
        {
            if (!File.Exists(_path)) File.Create(_path).Close();
        }

        public void Add(Book book)
        {
            List<Book> dbBooks = ReadFromDb();

            if (dbBooks == null) dbBooks = new();

            book.Id = Guid.NewGuid().ToString();
            dbBooks.Add(book);

            WriteToDb(dbBooks);

            Console.WriteLine("Book added");
        }

        public void AddRange(List<Book> newBooks)
        {
            foreach (Book book in newBooks)
                Add(book);
        }

        public void Remove(string id)
        {
            List<Book> dbBooks = ReadFromDb();

            Book book = dbBooks.Find(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            dbBooks.Remove(book);
            WriteToDb(dbBooks);
            Console.WriteLine("Book deleted");
        }

        public void Update(string id)
        {
            List<Book> dbBooks = ReadFromDb();

            Book book = dbBooks.Find(b => b.Id == id);

            book.Title = "Updated";

            WriteToDb(dbBooks);
            Console.WriteLine("Book updated");
        }

        public void ShowBook(string id)
        {
            List<Book> dbBooks = ReadFromDb();

            Book book = dbBooks.Find(b => b.Id == id);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            Console.WriteLine(book);
        }

        public void ShowAllBooks()
        {
            List<Book> dbBooks = ReadFromDb();

            dbBooks.ForEach(b => Console.WriteLine(b));
        }

        private List<Book> ReadFromDb()
        {
            string result;

            using (StreamReader reader = new(_path))
            {
                result = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Book>>(result);
        }

        private void WriteToDb(List<Book> books)
        {
            string json = JsonConvert.SerializeObject(books);

            using (StreamWriter writer = new(_path))
            {
                writer.Write(json);
            }
        }
    }
}
