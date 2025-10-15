interface IGeoObject
{
    int X { get; set; }
    int Y { get; set; }
    string Name { get; set; }
    string Description { get; set; }

    void GetInfo();
}

class River : IGeoObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double FlowSpeed { get; set; }
    public double Length { get; set; }

    public River(int x, int y, string name, string description, double flowSpeed, double length)
    {
        X = x;
        Y = y;
        Name = name; 
        Description = description;
        FlowSpeed = flowSpeed; 
        Length = length;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Опис: {Description}");
        Console.WriteLine($"Координати: ({X}, {Y})");
        Console.WriteLine($"Швидкість течії: {FlowSpeed}");
        Console.WriteLine($"Довжина: {Length}");
    }
}

class Mountain : IGeoObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double HighestPoint { get; set; }

    public Mountain(int x, int y, string name, string description, double highestPoint)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
        HighestPoint = highestPoint;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Опис: {Description}");
        Console.WriteLine($"Координати: ({X}, {Y})");
        Console.WriteLine($"Найвища точка: {HighestPoint}");
    }
}

class Program
{
    static void Main()
    {
        IGeoObject river = new River(50, 30, "Дніпро", "Велика річка України", 120, 2200);
        IGeoObject mountain = new Mountain(48, 24, "Говерла", "Найвища гора України", 2061);

        river.GetInfo();
        Console.WriteLine();
        mountain.GetInfo();
    }
}