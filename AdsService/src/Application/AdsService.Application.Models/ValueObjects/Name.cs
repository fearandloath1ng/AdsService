namespace AdsService.Application.Models.ValueObjects;

public readonly struct Name
{
    public string Value { get; }

    public Name(string value)
    {
        Value = value;
        if (value.Length > 30)
            throw new ArgumentException("Name length can't exceed 30 symbols.", nameof(value));
    }

    public Name()
    {
        Value = "Empty name";
    }
}