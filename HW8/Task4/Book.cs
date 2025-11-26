using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Book : IPriceable, IDiscountable
    {
        public double Price { get; private set; }
        public double DiscountPercent { get; private set; } = 0;

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
            if (promocode == "BOOK10")
            {
                DiscountPercent = 10;
            }
        }

        public double GetFinalPrice()
        {
            return Price * (1 - DiscountPercent / 100.0);
        }
    }

}
