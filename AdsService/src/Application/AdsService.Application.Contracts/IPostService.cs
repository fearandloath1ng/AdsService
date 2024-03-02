using AdsService.Application.Models.Dto;

namespace AdsService.Application.Contracts;

public interface IPostService
{
    public PostDto CreatePost(Jwt jwt, PostContent content);
    public PostStatus GetStatus(Jwt jwt, Guid postId);
    public string GetRejectionReason(Jwt jwt, Guid postId);
    public IReadOnlyCollection<PostDto> GetAllPostsForModeration(Jwt jwt);
    public IReadOnlyCollection<PostDto> GetAllPosts(Jwt jwt);
}