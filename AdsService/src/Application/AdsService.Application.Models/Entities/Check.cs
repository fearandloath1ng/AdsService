namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public enum CheckResult
{
    Approved,
    Rejected
}

public class Check
{
    public Guid Id { get; }
    public Moderator Moderator { get; }
    public Post Post { get; }
    public CheckResult Result { get; }
    public Reason Reason { get; }

    private Check(Post post, Moderator moderator, CheckResult result, Reason reason)
    {
        Id = Guid.NewGuid();
        Moderator = moderator ?? throw new ArgumentNullException(nameof(moderator));
        Post = post ?? throw new ArgumentNullException(nameof(post));
        Result = result;
        Reason = reason;
    }

    public static Check ApproveCheck(Post post, Moderator moderator)
    {
        return new Check(post, moderator, true, default);
    }

    public static Check RejectCheck(Post post, Moderator moderator, Reason reason)
    {
        return new Check(post, moderator, false, reason);
    }
}
