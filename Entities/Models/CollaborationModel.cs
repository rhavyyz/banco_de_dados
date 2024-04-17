// CREATE table Collaboration
// (
// 	    user_email  int,
//   	id_post int,
//   	id_Collaboration_permission int,
//   	PRIMARY key(id_user, guid_post),
//   	FOREIGN key(id_user) REFERENCES User(id),
//   	FOREIGN key(id_post) REFERENCES Post(id),
//   	FOREIGN key(id_Collaboration_permission) REFERENCES Collaboration_Permission(id)
// );

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Entities.Views;

namespace Entities.Models;


[PrimaryKey(nameof(user_email ), nameof(guid_post))]
public class CollaborationModel
{
    [ForeignKey(nameof(User))]
    public string user_email  { get; set; }
    [ForeignKey(nameof(Post))]
    public Guid guid_post { get; set; }
    [ForeignKey(nameof(CollaborationPermission))]
    public Guid guid_Collaboration_permission { get; set; }

    // navigation properties
    public virtual UserModel User { get; set; }
    public virtual PostModel Post { get; set; }
    public virtual CollaborationPermissionModel CollaborationPermission { get; set; }


    public Collaboration toView()
    {
        return new Collaboration{
            guid_post = this.guid_post,
            post_title = this.Post.title,
            user_email = this.user_email,
            user_name = this.User.name,
            permission = this.CollaborationPermission.toView()
        };
    }
}