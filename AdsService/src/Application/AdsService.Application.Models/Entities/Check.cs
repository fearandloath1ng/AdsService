namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class Check
{
    public Guid Id { get; }

    public Guid ModeratorId { get; }

    public Guid PostId { get; }

    public bool Result { get; }

    public Reason Reason { get; }

    private Check(Post post, Moderator moderator, bool result, Reason reason)
    {
        Id = Guid.NewGuid();
        ModeratorId = moderator.Id;
        PostId = post.Id;
        Result = result;
        Reason = reason;
    }

    public static Check ApproveCheck(Post post, Moderator moderator)
    {
        return new(post, moderator, true, default);
    }

    public static Check RejectCheck(Post post, Moderator moderator, Reason reason)
    {
        return new(post, moderator, false, reason);
    }
}