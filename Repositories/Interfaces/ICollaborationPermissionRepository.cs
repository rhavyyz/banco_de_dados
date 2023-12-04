using Models;
namespace Repositories.Interfaces;

public interface ICollaborationPermissionRepository
{
    public Task add(CollaborationPermissionModel collaborationPermission);
    public Task delete(CollaborationPermissionModel collaborationPermission);
    public IQueryable<CollaborationPermissionModel> getAll();
}