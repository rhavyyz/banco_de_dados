using Models;
namespace Services.Interfaces;

public interface ICollaborationPermissionService
{
    public Task add(CollaborationPermissionModel collaborationPermission);
    public Task delete(CollaborationPermissionModel collaborationPermission);
}