using Models;
using Views;
namespace Services.Interfacess;

public interface IUserPermissionService
{


    public Task add(UserPermission userPermission);
    public Task delete(UserPermission userPermission);
    public IQueryable<UserPermission> getAll();
}