using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTable.Product
{
    internal class Product
    {
        public double Price { get; private set; }
        public string Country { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Description { get; private set; }
        public string Kind => GetType().Name;

        protected Product(double price, string country, string name, DateTime createdAt, string description)
        {
            Price = price;
            Country = country;
            Name = name;
            CreatedAt = createdAt;
            Description = description;
        }
    }
}
