using Models;

namespace Views;
public class Collaboration
{
    public string user_email { get; set; }

    public string user_name { get; set; }

    public Guid guid_post { get; set; }
    public string post_title { get; set; }

    public CollaborationPermission permission { get; set; }


    public CollaborationModel toModel()
    {
        CollaborationModel c = new CollaborationModel{
            user_email = this.user_email,
            guid_post = this.guid_post,
        };

        if (this.permission != null)
            c.guid_Collaboration_permission = this.permission.guid;

        return c;
    }
}