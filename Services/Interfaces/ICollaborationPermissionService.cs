using Models;
using Views;
namespace Services.Interfacess;

public interface ICollaborationPermissionService
{

    public Task add(CollaborationPermission collaborationPermission);
    public Task delete(CollaborationPermission collaborationPermission);
    public IQueryable<CollaborationPermission> getAll();
}