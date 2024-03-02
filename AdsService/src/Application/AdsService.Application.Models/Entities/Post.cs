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

    public void Approve(Moderator moderator)
    {
        ThrowIfNotOnModeration();
        Check = Check.ApproveCheck(this, moderator);
    }

    public void Reject(Moderator moderator, Reason reason)
    {
        ThrowIfNotOnModeration();
        Check = Check.RejectCheck(this, moderator, reason);
    }

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

    private void ThrowIfNotOnModeration()
    {
        if (ModerationStatus != PostStatus.Moderation)
            throw new InvalidOperationException("Post is not on moderation.");
    }
}