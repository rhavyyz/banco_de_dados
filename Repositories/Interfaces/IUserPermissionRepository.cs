using Entities.Models;
using Entities.Views;
namespace Repositories.Interfaces;

public interface IUserPermissionRepository
{
    public Task add(UserPermission userPermission);
    public Task delete(UserPermission userPermission);
    public IQueryable<UserPermission> getAll();
}