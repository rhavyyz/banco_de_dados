namespace Views;
public class Collaboration
{
    public string user_email { get; set; }

    public string user_name { get; set; }

    public Guid guid_post { get; set; }
    public string post_title { get; set; }

    public CollaborationPermission permission { get; set; }
}