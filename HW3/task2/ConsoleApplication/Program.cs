using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Write("Введіть ціле число: ");
        string? input = Console.ReadLine();

        if (input is null || !int.TryParse(input, out int number))
        {
            Console.WriteLine("Введено некоректне значення");
        } else
        {
            Console.WriteLine("Ви ввели число: " + number);
        }
    }
}