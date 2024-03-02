namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface ICampaignService
{
    void StartCampaign(Jwt jwt, Guid postId, TimeSpan duration, CampaignParameters parameters);

    bool TryStopCampaign(Jwt jwt, Guid campaignId);

    bool TryGetAnalytics(Jwt jwt, Guid campaignId, out CampaignAnalytics analytics);

    IEnumerable<Guid> GetCampaigns(Jwt jwt);
}