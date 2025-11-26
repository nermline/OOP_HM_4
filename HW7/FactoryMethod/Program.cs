using System;
using System.Text;

namespace FactoryMethodExample
{
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                case 1: return new WordDocument();
                case 2: return new PdfDocument();
                default:
                    throw new ArgumentException("Invalid type.", nameof(type));
            }
        }
    }

    public abstract class Product
    {
        public abstract void Print();
    }


    public class WordDocument : Product
    {
        public override void Print()
        {
            Console.WriteLine("Друк документа Word");
        }
    }

    public class PdfDocument : Product
    {
        public override void Print()
        {
            Console.WriteLine("Друк документа PDF");
        }
    }

    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Creator creator = new ConcreteCreator();

            for (int i = 1; i <= 2; i++)
            {
                Product product = creator.FactoryMethod(i);
                Console.Write("Для type = {0}: ", i);
                product.Print();
            }

            Console.ReadKey();
        }
    }
}
