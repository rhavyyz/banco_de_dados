
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Views;

namespace Models;

[PrimaryKey(nameof(user_email), nameof(guid_post))]
public class LikeModel
{
    [ForeignKey(nameof(User))]
    public string user_email { get; set; }
    [ForeignKey(nameof(Post))]
    public Guid guid_post { get; set; }

    public virtual UserModel User { get; set; }
    public virtual PostModel Post { get; set; }

    public static PostLikes toPostLikes(List<LikeModel> likes)
    {
        PostLikes pLikes = new PostLikes();
        foreach (var like in likes)
            pLikes.likes.Add(new PostLikes.Like{
                user_email = like.user_email,
                username = like.User.name
                });

        return pLikes;
    }
    public static UserLikes toUserLikes(List<LikeModel> likes)
    {
        UserLikes uLikes = new UserLikes();
        foreach (var like in likes)
            uLikes.likes.Add(new UserLikes.Like{
                guid_post = like.guid_post,
                title = like.Post.title
                });

        return uLikes;
    }

}