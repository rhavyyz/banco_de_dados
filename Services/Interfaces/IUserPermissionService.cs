using Models;
using Views;
namespace Services.Interfaces;

public interface IUserPermissionService
{
    public static UserPermissionModel ViewToModel(UserPermission userPermission)
    {
        return new UserPermissionModel{
            guid = userPermission.guid,
            name = userPermission.name
        };
    }
    public static UserPermission ModelToView(UserPermissionModel userPermission)
    {
        return new UserPermission{
            guid = userPermission.guid,
            name = userPermission.name
        };
    }
    public Task add(UserPermission userPermission);
    public Task delete(UserPermission userPermission);
    public IQueryable<UserPermission> getAll();
}