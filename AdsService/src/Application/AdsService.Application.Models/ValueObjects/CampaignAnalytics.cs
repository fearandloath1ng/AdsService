namespace AdsService.Application.Models.ValueObjects;

public readonly struct CampaignAnalytics
{
    public int Clicks { get; init; }

    internal CampaignAnalytics(int clicks)
    {
        // TODO: Add more metrics.
        Clicks = clicks;
    }
}