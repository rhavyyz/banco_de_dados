using Entities.Models;
using Entities.Views;
namespace Repositories.Interfaces;

public interface ICollaborationPermissionRepository
{
    public Task add(CollaborationPermission collaborationPermission);
    public Task delete(CollaborationPermission collaborationPermission);
    public IQueryable<CollaborationPermission> getAll();
}