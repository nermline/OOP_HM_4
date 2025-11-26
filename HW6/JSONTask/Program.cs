using System.Text;
using System.Text.Json;
using JSONTask;
using System.Text.Encodings.Web;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string json = File.ReadAllText("file.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        List<Book>? books = JsonSerializer.Deserialize<List<Book>>(json, options);

        Console.WriteLine("Десеріалізовані книги:\n");
        if (books != null)
        {
            foreach (var b in books)
            {
                Console.WriteLine($"Назва: {b.Title}");
                Console.WriteLine($"Видавництво: {b.PublishingHouse.Name}");
                Console.WriteLine($"Адреса: {b.PublishingHouse.Adress}");
                Console.WriteLine();
            }

            Console.WriteLine("Серіалізований назад JSON:\n");

            string serialized = JsonSerializer.Serialize(books, options);
            Console.WriteLine(serialized);
        }
        else
        {
            Console.WriteLine("Не вдалося десеріалізувати JSON.");
        }
    }
}
