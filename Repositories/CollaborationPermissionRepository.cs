using WebApi.Helpers;
using Models;
using Repositories.Interfaces;
namespace Repositories;

public class CollaborationPermissionRepository : ICollaborationPermissionRepository
{

    private readonly ApplicationContext _context;

    public async Task add(CollaborationPermissionModel collaborationPermission)
    {
        await _context.CollaborationPermissions.AddAsync(collaborationPermission);
        await _context.SaveChangesAsync();    
    }

    public async Task delete(CollaborationPermissionModel collaborationPermission)
    {
        _context.CollaborationPermissions.Remove(collaborationPermission);
        await _context.SaveChangesAsync();    
    }
}