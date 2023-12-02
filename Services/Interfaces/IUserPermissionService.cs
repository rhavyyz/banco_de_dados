using Models;
namespace Services.Interfaces;

public interface IUserPermissionService
{
    public Task add(UserPermissionModel userPermission);
    public Task delete(UserPermissionModel userPermission);

}