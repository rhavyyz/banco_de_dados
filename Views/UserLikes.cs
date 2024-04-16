using Models;

namespace Views;
public class UserLikes
{
    public struct Like 
    {
        public Guid guid_post { get; set;}
        public string title { get; set;}
    }

    public List<UserLikes.Like> likes { get; set; } = new List<UserLikes.Like>(); 


    public List<LikeModel> toModel(User user)
    {
        var likes = new List<LikeModel>();

        foreach (var uLike in this.likes)
            likes.Add(new LikeModel{
                guid_post = uLike.guid_post,
                user_email = user.email
            });
        
        return likes;
    }

}