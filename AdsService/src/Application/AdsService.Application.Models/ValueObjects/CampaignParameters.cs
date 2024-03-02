namespace AdsService.Application.Models.ValueObjects;

public readonly struct CampaignParameters
{
    public bool IsTargetingChild { get; init; }

    public CampaignParameters(bool isTargetingChild)
    {
        // TODO: Add more parameters.
        IsTargetingChild = isTargetingChild;
    }
}