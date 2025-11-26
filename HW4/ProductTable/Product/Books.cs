using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTable.Product
{
    internal class Books : Product
    {
        public int PagesAmount { get; private set; }
        public string PublishingHouse { get; private set; }
        public List<string> Authors { get; private set; }

        public string AuthorsText => string.Join(", ", Authors);
        public Books(double price, string country, string name, DateTime createdAt, string description, int pagesAmount, string publishingHouse, List<string> authors)
            : base(price, country, name, createdAt, description)
        {
            PagesAmount = pagesAmount;
            PublishingHouse = publishingHouse;
            Authors = authors;
        }
    }
}
