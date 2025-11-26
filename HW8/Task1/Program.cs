// Порушено принцип єдиної відповідальності

using System;
using System.Collections.Generic;
class Item
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
}

class Order
{
    private readonly List<Item> _items = new List<Item>();

    public IReadOnlyList<Item> Items => _items.AsReadOnly();

    public void AddItem(Item item) => _items.Add(item);

    public void DeleteItem(Item item) => _items.Remove(item);

    public int GetItemCount() => _items.Count;

    public double CalculateTotalSum()
    {
        double sum = 0;
        foreach (var item in _items)
            sum += item.Price;
        return sum;
    }
}

class OrderPrinter
{
    public void PrintOrder(Order order)
    {
        Console.WriteLine("Замовлення:");
        foreach (var item in order.Items)
            Console.WriteLine($"- {item.Name}: {item.Price}");
        Console.WriteLine($"Разом: {order.CalculateTotalSum()}");
    }

    public void ShowOrder(Order order)
    {
        PrintOrder(order);
    }
}

class OrderRepository
{
    public void Save(Order order)
    {
    }

    public Order Load(int id)
    {
        return new Order();
    }

    public void Update(Order order)
    {
    }

    public void Delete(int id)
    {
    }
}

