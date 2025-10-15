class Converter
{
    private decimal usdRate;
    private decimal eurRate;

    public Converter(decimal usd, decimal eur)
    {
        usdRate = usd;
        eurRate = eur;
    }

    public decimal UAHtoUSD(decimal uah)
    {
        return uah / usdRate;
    }

    public decimal UAHtoEUR(decimal uah)
    {
        return uah / eurRate;
    }

    public decimal USDtoUAH(decimal usd)
    {
        return usd * usdRate;
    }

    public decimal EURtoUAH(decimal eur)
    {
        return eur * eurRate;
    }
}

class Program
{
    static void Main()
    {
        decimal usdRate = 41.75m;
        decimal eurRate = 48.55m;

        Converter converter = new Converter(usdRate, eurRate);

        Console.WriteLine($"{converter.UAHtoUSD(20000):F2}");
        Console.WriteLine($"{converter.UAHtoEUR(20000):F2}");
        Console.WriteLine($"{converter.USDtoUAH(701):F2}");
        Console.WriteLine($"{converter.EURtoUAH(1003):F2}");
    }

}