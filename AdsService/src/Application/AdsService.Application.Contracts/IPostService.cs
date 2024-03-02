namespace AdsService.Application.Contracts;

using AdsService.Application.Models.Dto;
using AdsService.Application.Models.ValueObjects;

public interface IPostService
{
    public PostDto CreatePost(Jwt jwt, PostContent content);

    public PostStatus GetStatus(Jwt jwt, Guid postId);

    public bool TryGetRejectionReason(Jwt jwt, Guid postId, out Reason rejectionReason);

    public IReadOnlyCollection<PostDto> GetAllPostsForModeration(Jwt jwt);

    public IReadOnlyCollection<PostDto> GetAllPosts(Jwt jwt);
}