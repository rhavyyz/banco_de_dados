using Models;
using Views;
namespace Services.Interfaces;

public interface ICollaborationPermissionService
{
    public static CollaborationPermission ModelToView(CollaborationPermissionModel collaborationPermission)
    {
        return new CollaborationPermission{
            guid = collaborationPermission.guid,
            name = collaborationPermission.name
        };
    }
    public static CollaborationPermissionModel ViewToModel(CollaborationPermission collaborationPermission)
    {
        return new CollaborationPermissionModel{
            guid = collaborationPermission.guid,
            name = collaborationPermission.name
        };
    }
    public Task add(CollaborationPermission collaborationPermission);
    public Task delete(CollaborationPermission collaborationPermission);
    public IQueryable<CollaborationPermission> getAll();
}