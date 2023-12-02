using Models;

public interface ICollaborationPermissionRepository
{
    public Task add(CollaborationPermissionModel collaborationPermission);
    public Task delete(CollaborationPermissionModel collaborationPermission);
}