namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class Post(User user, PostContent content)
{
    public Guid Id { get; } = Guid.NewGuid();

    public Guid UserId { get; } = user.Id;

    public PostContent Content { get; } = content;

    public PostStatus ModerationStatus =>
        Check is null ? PostStatus.Moderation : (Check.Result ? PostStatus.Approved : PostStatus.Rejected);

    private Check? Check { get; set; }

    public bool TryGetRejectReason(out Reason reason)
    {
        if (ModerationStatus != PostStatus.Rejected)
        {
            reason = default;
            return false;
        }

        reason = Check!.Reason;
        return true;
    }
}