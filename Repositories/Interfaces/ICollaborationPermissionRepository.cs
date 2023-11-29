using Models;
namespace Repositories.Interfaces;

public interface ICollaborationPermissionRepository
{
    public void add(CollaborationPermissionModel collaborationPermission);
    public void delete(CollaborationPermissionModel collaborationPermission);
}