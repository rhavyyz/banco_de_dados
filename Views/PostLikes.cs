using Models;

namespace Views;
public class PostLikes
{
    public struct Like 
    {
        public string user_email { get; set;}
        public string username { get; set;}
    }

    public List<PostLikes.Like> likes { get; set; } = new List<PostLikes.Like>(); 

    public List<LikeModel> toModel(Post post)
    {
        var likes = new List<LikeModel>();

        foreach (var pLike in this.likes)
            likes.Add(new LikeModel{
                guid_post = post.guid,
                user_email = pLike.user_email
            });
        
        return likes;
    }

}