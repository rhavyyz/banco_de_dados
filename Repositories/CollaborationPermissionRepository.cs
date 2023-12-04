using WebApi.Helpers;
using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;


namespace Repositories;

public class CollaborationPermissionRepository : ICollaborationPermissionRepository
{

    private readonly ApplicationContext _context;

    public CollaborationPermissionRepository(ApplicationContext context)
    {
        _context = context;
    }
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

    public IQueryable<CollaborationPermissionModel> getAll()
    {
        return _context.CollaborationPermissions.AsQueryable();
    }
}