using Models;
namespace Repositories.Interfaces;

public interface IUserPermissionRepository
{
    public void add(UserPermissionModel userPermission);
    public void delete(UserPermissionModel userPermission);

}