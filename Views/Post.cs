using Models;

namespace Views;
public class Post
{
    public Guid guid{get; set;}
    public string title {get; set;}
    public string subtitle {get; set;}
    public string content {get; set;}
    public DateTime? date {get; set;}
    public bool approved {get; set;}
    public string user_email {get; set;} 
    public string username {get; set;} 
    public int n_likes { get; set; }
    public List<Category> Categories { get; set; }

    public PostModel toModel()
    {
        return new PostModel{
            approved = this.approved,
            content = this.content,
            date = this.date.HasValue ? (DateTime)this.date : DateTime.Now.ToUniversalTime(),
            guid = this.guid,
            user_email = this.user_email,
            title = this.title,
            subtitle = this.subtitle,            
        };
    }
}