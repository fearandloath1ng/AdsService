namespace AdsService.Application.Models.Dto;

public record AdCampaignDto(Guid Id, Guid PostId, Guid UserId, AdCampaignCost Cost, TimeSpan Duration, IsActive IsActive);