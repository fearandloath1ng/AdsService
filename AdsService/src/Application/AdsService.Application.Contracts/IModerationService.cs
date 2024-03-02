namespace AdsService.Application.Contracts;

using AdsService.Application.Models.ValueObjects;

public interface IModerationService
{
    void ApprovePost(Jwt jwt, Guid postId);

    void RejectPost(Jwt jwt, Guid postId, Reason reason);
}