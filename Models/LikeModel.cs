
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

[PrimaryKey(nameof(user_email), nameof(guid_post))]
public class LikeModel
{
    [ForeignKey(nameof(User))]
    public string user_email { get; set; }
    [ForeignKey(nameof(Post))]
    public Guid guid_post { get; set; }

    public virtual UserModel User { get; set; }
    public virtual PostModel Post { get; set; }

}