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



using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Views;

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
    public DateTime publish_date {get;set;}

    // Navigation properties
    public virtual UserModel User { get; set; }
    public virtual PostModel Post { get; set; }

    public Comment ModelToView() 
    {
        return new Comment{
            guid = this.guid,
            guid_post = this.guid_post,
            content = this.content, 
            post_title = this.Post.title,
            publish_date = this.publish_date,
            user_email = this.user_email,
            username = this.User.name
        };
    }

}