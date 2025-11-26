using System;
using System.Text;

namespace AdapterExample
{
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "Підключено до старої системи (тонка розетка)";
        }
    }

    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "Підключено до нової системи (широка розетка)";
        }
    }

    class Adapter : INewElectricitySystem
    {
        private readonly OldElectricitySystem _adaptee;

        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            return _adaptee.MatchThinSocket();
        }
    }

    class ElectricityConsumer
    {
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            var oldElectricitySystem = new OldElectricitySystem();
            INewElectricitySystem adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);

            Console.ReadKey();
        }
    }
}
