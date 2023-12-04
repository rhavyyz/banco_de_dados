using Models;
namespace Repositories.Interfaces;

public interface IUserPermissionRepository
{
    public Task add(UserPermissionModel userPermission);
    public Task delete(UserPermissionModel userPermission);
    public IQueryable<UserPermissionModel> getAll();
}