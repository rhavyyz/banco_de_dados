namespace Views;
public class UserLikes
{
    public struct Like 
    {
        public Guid guid_post { get; set;}
        public string title { get; set;}
    }

    public List<UserLikes.Like> likes { get; set; } = new List<UserLikes.Like>(); 

}