using Models;

namespace Services.Interfaces;

public interface ICollaborationService
{
    public Task add(CollaborationPermissionModel collaborationPermission);
    public Task delete(CollaborationPermissionModel collaborationPermission);
}