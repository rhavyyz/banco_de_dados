using Entities.Models;
namespace Entities.Views;

public class CollaborationPermission //: CollaborationPermissionModel
{
    public Guid guid {get; set;}

    public string name {get; set;}

    public CollaborationPermissionModel toModel()
    {
        return new CollaborationPermissionModel{
            guid = this.guid,
            name = this.name
        };
    }
}
