using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public interface IPriceable
    {
        void SetPrice(double price);
    }

    public interface IDiscountable
    {
        void ApplyDiscount(string discount);
        void ApplyPromocode(string promocode);
    }

    public interface IColorable
    {
        void SetColor(byte color);
    }

    public interface ISizable
    {
        void SetSize(byte size);
    }

}
