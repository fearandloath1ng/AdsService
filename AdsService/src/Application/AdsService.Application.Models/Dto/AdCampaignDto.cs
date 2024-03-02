namespace AdsService.Application.Models.Dto;

using AdsService.Application.Models.ValueObjects;

public record AdCampaignDto(Guid Id, Guid PostId, Guid UserId, Cost Cost, DateTime StartedAt, TimeSpan Duration,
    bool IsActive);