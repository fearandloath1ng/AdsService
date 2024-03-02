namespace AdsService.Application.Models.ValueObjects;

public readonly struct PostContent
{
    public string Text { get; }

    public PostContent(string text)
    {
        Text = text;
        if (text.Length > 1024)
            throw new ArgumentException("Content length can't exceed 1024 symbols.", nameof(text));
    }

    public PostContent()
    {
        Text = "Empty content";
    }
}