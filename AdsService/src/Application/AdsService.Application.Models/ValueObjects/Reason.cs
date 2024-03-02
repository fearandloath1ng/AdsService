namespace AdsService.Application.Models.ValueObjects;

public readonly struct Reason
{
    public string Value { get; }

    public Reason(string value)
    {
        Value = value;
        if (value.Length > 100)
            throw new ArgumentException("Reason length can't exceed 100 symbols.", nameof(value));
    }

    public Reason()
    {
        Value = "Empty reason";
    }
}