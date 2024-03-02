namespace AdsService.Application.Models.Dto;

using AdsService.Application.Models.ValueObjects;

public record PostDto(Guid Id, Guid UserId, PostContent Content, PostStatus ModerationStatus);