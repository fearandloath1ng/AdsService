using AdsService.Application.Models.Dto;

namespace AdsService.Application.Contracts;

public interface IPostService
{
    public PostDto CreatePost(Jwt jwt, PostContent content);
    public PostStatus GetStatus(Jwt jwt, Guid postId);
    public bool TryGetRejectionReason(Jwt jwt, Guid postId, out string rejectionReason);
    public IReadOnlyCollection<PostDto> GetAllPostsForModeration(Jwt jwt);
    public IReadOnlyCollection<PostDto> GetAllPosts(Jwt jwt);
}