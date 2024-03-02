namespace AdsService.Application.Contracts;

using AdsService.Application.Models.Dto;
using AdsService.Application.Models.ValueObjects;

public interface ICampaignService
{
    AdCampaignDto StartCampaign(Jwt jwt, Guid postId, TimeSpan duration, CampaignParameters parameters);

    bool TryStopCampaign(Jwt jwt, Guid campaignId);

    bool TryGetAnalytics(Jwt jwt, Guid campaignId, out CampaignAnalytics analytics);

    IReadOnlyCollection<AdCampaignDto> GetCampaigns(Jwt jwt);
}