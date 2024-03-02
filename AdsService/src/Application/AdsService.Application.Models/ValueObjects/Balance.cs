namespace AdsService.Application.Models.ValueObjects;

public readonly struct Balance
{
    public long Kopecks { get; }

    public Balance(int rubles, int kopecks)
    {
        Kopecks = (rubles * 100) + kopecks;
        if (Kopecks < 0)
            throw new ArgumentException("Cost can't be less than 0.");
    }

    public Balance()
    {
        Kopecks = 0;
    }

    public bool CanPay(Cost cost)
    {
        return Kopecks >= cost.Kopecks;
    }
}