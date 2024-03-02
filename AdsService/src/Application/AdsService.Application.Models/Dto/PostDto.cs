namespace AdsService.Application.Models.Dto;

public record PostDto(Guid Id, Guid UserId, PostContent Content, PostStatus ModerationStatus);