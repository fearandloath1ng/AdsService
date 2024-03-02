namespace AdsService.Application.Models.ValueObjects;

public readonly struct Cost
{
    public long Kopecks { get; }

    public Cost(int rubles, int kopecks)
    {
        Kopecks = (rubles * 100) + kopecks;
        if (Kopecks < 0)
            throw new ArgumentException("Cost can't be less than 0.");
    }

    public Cost()
    {
        Kopecks = 0;
    }
}