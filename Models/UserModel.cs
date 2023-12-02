// CREATE TABLE User
// (
//   	email char(30),
//   	name char(80),
//   	pass_hash varchar(30),
//   	id_permission int,
// 	    PRIMARY KEY(email),
//   	FOREIGN key(id_permission) REFERENCES User_Permission(id)
// );


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class UserModel
{
    [Key]
    public string email { get; set; }

    public string name { get; set; }

    // [ForeignKey]
    public int pass_hash { get; set; }

    [ForeignKey(nameof(UserPermission))]
    public Guid guid_permission { get; set; }

    public UserPermissionModel UserPermission { get; set; }
    public virtual List< PostModel > Posts { get; set; }
    public virtual List< LikeModel > Likes { get; set; }
    
    public virtual List<CommentModel> Comments { get; set; }
    public virtual List<CollaborationModel> Collaborations { get; set; }


}