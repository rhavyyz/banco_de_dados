namespace Views;
public class Comment
{
    public Guid guid { get; set; }
    public string content { get; set; }
    public string user_email  { get; set; }
    public string username { get; set; }
    public Guid guid_post { get; set; }
    public string post_title { get; set; }
    public DateTime? publish_date { get; set; }
}