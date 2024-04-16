// CREATE TABLE Collaboration_Permission
// (
//   	id int,
//   	name char(20),
// 	PRIMARY KEY(id)
// );


using System.ComponentModel.DataAnnotations;
using Views;

namespace Models;

public class CollaborationPermissionModel
{
    [Key]
    public Guid guid {get; set;}

    public string name {get; set;}

    public CollaborationPermission toView()
    {
        return new CollaborationPermission{
            guid = this.guid,
            name = this.name
        };
    }
}