using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    internal class Outerwear : IPriceable, IDiscountable, IColorable, ISizable
    {
        public double Price { get; private set; }
        public double DiscountPercent { get; private set; }

        public byte Color { get; private set; }
        public byte Size { get; private set; }

        public void SetPrice(double price)
        {
            Price = price;
        }

        public void ApplyDiscount(string discount)
        {
            if (discount.EndsWith("%") &&
                double.TryParse(discount.TrimEnd('%'), out double percent))
            {
                DiscountPercent = percent;
            }
        }

        public void ApplyPromocode(string promocode)
        {
            if (promocode == "COAT20")
            {
                DiscountPercent = 20;
            }
        }

        public void SetColor(byte color)
        {
            Color = color;
        }

        public void SetSize(byte size)
        {
            Size = size;
        }

        public double GetFinalPrice()
        {
            return Price * (1 - DiscountPercent / 100.0);
        }
    }
}
