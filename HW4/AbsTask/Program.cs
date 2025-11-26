abstract class GeoObject
{
    private int X;
    private int Y;
    private string Name;
    private string Description;

    public GeoObject(int x, int y, string name, string description)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
    }

    public virtual void GetInfo()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Опис: {Description}");
        Console.WriteLine($"Координати: ({X}, {Y})");
    }
}

class River : GeoObject
{
    private double FlowSpeed;
    private double Length;

    public River(int x, int y, string name, string description, double flowSpeed, double length) : base(x, y, name, description)
    {
        FlowSpeed = flowSpeed;
        Length = length;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Швидкість течії: {FlowSpeed}");
        Console.WriteLine($"Довжина: {Length}");
    }
}

class Mountain : GeoObject
{
    private double HighestPoint;

    public Mountain(int x, int y, string name, string description, double highestPoint) : base(x, y, name, description)
    {
        HighestPoint = highestPoint;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Найвища точка: {HighestPoint}");
    }
}

class Program
{
    static void Main()
    {
        River river = new River(50, 30, "Дніпро", "Велика річка України", 120, 2200);
        Mountain mountain = new Mountain(48, 24, "Говерла", "Найвища гора України", 2061);

        river.GetInfo();
        Console.WriteLine();
        mountain.GetInfo();
    }
}