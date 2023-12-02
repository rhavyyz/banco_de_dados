namespace Views;
public class Post
{
    public Guid guid{get; set;}
    public string title {get; set;}
    public string subtitle {get; set;}
    public string content {get; set;}
    public DateTime date {get; set;}
    public bool approved {get; set;}
    public string user_email {get; set;} 
    public string username {get; set;} 
    public int n_likes { get; set; }
}