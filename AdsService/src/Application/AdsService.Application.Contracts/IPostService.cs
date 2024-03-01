namespace AdsService.Application.Contracts;

public interface IPostService
{
    public Post CreatePost(Jwt jwt, PostContent content);
    public PostStatus GetStatus(Jwt jwt, Guid postId);
    public string GetRejectionReason(Jwt jwt, Guid postId);
    public IReadOnlyCollection<Post> GetAllPostsForModeration(Jwt jwt);
    public IReadOnlyCollection<Post> GetAllPosts(Jwt jwt);
}