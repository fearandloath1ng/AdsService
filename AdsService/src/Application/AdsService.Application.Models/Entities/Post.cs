namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class Post
{
    public Guid Id { get; } = Guid.NewGuid();

    public User User { get; }

    public PostContent Content { get; }

    public Post(User user, PostContent content)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        User = user;
        Content = content;
    }

    public PostStatus ModerationStatus =>
        Check is null ? PostStatus.Moderation : (Check.Result == CheckResult.Approved ? PostStatus.Approved : PostStatus.Rejected);

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