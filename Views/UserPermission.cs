using Models;

namespace Views;
public class UserPermission
{
    public Guid guid { get; set; } 
    public string name { get; set; }
    public UserPermissionModel ViewToModel()
    {
        return new UserPermissionModel{
            guid = this.guid,
            name = this.name
        };
    }
}