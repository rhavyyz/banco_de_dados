using Entities.Models;

namespace Entities.Views;
public class Comment
{
    public Guid guid { get; set; }
    public string content { get; set; }
    public string user_email  { get; set; }
    public string username { get; set; }
    public Guid guid_post { get; set; }
    public string post_title { get; set; }
    public DateTime? publish_date { get; set; }

    public CommentModel toModel()
    {
        return new CommentModel{
            guid = this.guid,
            content = this.content,
            guid_post = this.guid_post,
            publish_date = this.publish_date.HasValue ? (DateTime)this.publish_date : DateTime.Now.ToUniversalTime(),
            user_email = this.user_email
        };
    }
}