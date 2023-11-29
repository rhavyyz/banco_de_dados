// CREATE TABLE Post
// (
//   	id int,
//   	title varchar(20),
//   	subtitle varchar(40),
//   	content varchar(200),
//   	date varchar(10),
//   	approved char(10),
//   	id_user int,
//   	PRIMARY KEY(id),
//   	FOREIGN KEY(id_user) REFERENCES User(id)
// );


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class PostModel
{
    [Key]
    public Guid guid{get; set;}

    public string title {get; set;}

    public string subtitle {get; set;}

    public string content {get; set;}

    public DateTime date {get; set;}

    public bool approved {get; set;}

    [ForeignKey(nameof(User))]
    public string user_email {get; set;} 

    // Navigation properties
    public UserModel User { get; set; }

    // [NotMapped]
    public List<LikeModel> Likes { get; set; }
    public List<CategoryModel> Categories { get; set; }
    public List<CollaborationModel> Collaborations { get; set; }
    public List<CommentModel> Comments { get; set; }

    // public override void On
}