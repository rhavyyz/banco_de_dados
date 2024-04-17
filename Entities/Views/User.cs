using Entities.Models;

namespace Entities.Views;
public class User
{   
    public string email { get; set; }
    public string name { get; set; }
    public UserPermission permission { get; set; }

    public UserModel toModel()
    {
        var u = new UserModel{
            email = this.email,
            name = this.name,
        };

                       
        if( this.permission != null)
            u.guid_permission = this.permission.guid;

        return u;
    }
}