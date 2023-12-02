namespace Views;
public class Collaboration
{
    public string user_email { get; set; }

    public string user_name { get; set; }

    public Guid guid_post { get; set; }
    public Guid post_title { get; set; }

    public Guid guid_collaboration_permission { get; set; }
    public string collaboration_permission_name { get; set; }
}