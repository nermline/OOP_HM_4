using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTable.Product
{
    internal class Groceries : Product
    {
        public DateTime ExpirationDate { get; private set; }
        public int Amount { get; private set; }
        public string MeasurementUnit { get; private set; }

        public Groceries(double price, string country, string name, DateTime createdAt, string description, DateTime expirationDate, int amount, string measurementUnit)
            : base(price, country, name, createdAt, description)
        {
            ExpirationDate = expirationDate;
            Amount = amount;
            MeasurementUnit = measurementUnit;
        }
    }
}
