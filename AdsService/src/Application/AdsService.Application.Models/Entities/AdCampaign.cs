namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class AdCampaign(Money cost, Post post, DateTime startedAt, TimeSpan duration, bool isActive)
{
    public Guid Id { get; } = Guid.NewGuid();

    public Guid PostId { get; } = post.Id;

    public Money Cost { get; } = cost;

    public DateTime StartedAt { get; } = startedAt;

    public TimeSpan Duration { get; } = duration;

    public bool IsActive { get; } = isActive;
}