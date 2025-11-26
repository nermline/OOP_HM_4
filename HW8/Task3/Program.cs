// Порушено принцип заміщення Лісков

using System;

interface IShape
{
    int GetArea();
}

class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int GetArea() => Width * Height;
}

class Square : IShape
{
    public int Side { get; set; }

    public Square(int side)
    {
        Side = side;
    }

    public int GetArea() => Side * Side;
}

class Program
{
    static void Main(string[] args)
    {
        IShape rect = new Rectangle(5, 10);
        Console.WriteLine(rect.GetArea());

        IShape square = new Square(5);
        Console.WriteLine(square.GetArea());

        Console.ReadKey();
    }
}

