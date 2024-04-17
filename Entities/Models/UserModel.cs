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
using Entities.Views;

namespace Entities.Models;

public class UserModel
{
    [Key]
    public string email { get; set; }

    public string name { get; set; }

    // [ForeignKey]
    public int pass_hash { get; set; } = -1;

    [ForeignKey(nameof(UserPermission))]
    public Guid guid_permission { get; set; }

    public UserPermissionModel UserPermission { get; set; }
    public virtual List< PostModel > Posts { get; set; }
    public virtual List< LikeModel > Likes { get; set; }
    
    public virtual List<CommentModel> Comments { get; set; }
    public virtual List<CollaborationModel> Collaborations { get; set; }

    public User toView()
    {
        Console.WriteLine($"\n\n\n{this.name}\n\n\n");

        return new User{
            email = this.email,
            name = this.name,
            permission = this.UserPermission.toView()
        };
    }

}