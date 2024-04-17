using Entities.Models;

namespace Entities.Views;
public class UserPermission
{
    public Guid guid { get; set; } 
    public string name { get; set; }
    public UserPermissionModel toModel()
    {
        return new UserPermissionModel{
            guid = this.guid,
            name = this.name
        };
    }
}