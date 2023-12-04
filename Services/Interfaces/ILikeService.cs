using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
using Views;
namespace Services.Interfaces;

public interface ILikeService
{
    public static PostLikes ModelToPostView(List<LikeModel> likes)
    {
        PostLikes pLikes = new PostLikes();
        foreach (var like in likes)
            pLikes.likes.Add(new PostLikes.Like{
                user_email = like.user_email,
                username = like.User.name
                });

        return pLikes;
    }
    public static UserLikes ModelToUserView(List<LikeModel> likes)
    {
        UserLikes uLikes = new UserLikes();
        foreach (var like in likes)
            uLikes.likes.Add(new UserLikes.Like{
                guid_post = like.guid_post,
                title = like.Post.title
                });

        return uLikes;
    }
    public static List<LikeModel> UserViewToModel(UserLikes  uLikes, User user)
    {
        var likes = new List<LikeModel>();

        foreach (var uLike in uLikes.likes)
            likes.Add(new LikeModel{
                guid_post = uLike.guid_post,
                user_email = user.email
            });
        
        return likes;
    }
    public static List<LikeModel> PostViewToModel(PostLikes pLikes, Post post)
    {
        var likes = new List<LikeModel>();

        foreach (var pLike in pLikes.likes)
            likes.Add(new LikeModel{
                guid_post = post.guid,
                user_email = pLike.user_email
            });
        
        return likes;
    }
    public Task add(Guid guid_post, string user_email);
    public Task delete(Guid guid_post, string user_email);
    public UserLikes getByUser(User user);
    public PostLikes getByPost(Post post);
}