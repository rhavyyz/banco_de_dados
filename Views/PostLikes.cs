namespace Views;
public class PostLikes
{
    public struct Like 
    {
        public string user_email { get; set;}
        public string username { get; set;}
    }

    public List<PostLikes.Like> likes { get; set; } = new List<PostLikes.Like>(); 

}