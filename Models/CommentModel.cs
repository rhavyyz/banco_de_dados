// CREATE table Comment
// (
//   	id int,
// 	    content varchar(200),
//   	publish_date varchar(10),
//   	id_user int,
//   	id_post int,
//   	PRIMARY KEY(id),
//   	FOREIGN key(id_user) REFERENCES User(id),
//   	FOREIGN key(id_post) REFERENCES Post(id)
// );



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class CommentModel
{
    [Key]
    public Guid guid { get; set; }

    public string content { get; set; }

    [ForeignKey(nameof(User))]
    public string user_email  { get; set; }

    [ForeignKey(nameof(Post))]
    public Guid guid_post { get; set; }
    public DateTime publish_date { get; set; }

    // Navigation properties
    public virtual UserModel User { get; set; }
    public virtual PostModel Post { get; set; }


}