using WebApi.Helpers;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Entities.Views;


namespace Repositories;

public class CollaborationPermissionRepository : ICollaborationPermissionRepository
{

    private readonly ApplicationContext _context;

    public CollaborationPermissionRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task add(CollaborationPermission collaborationPermission)
    {
        await _context.CollaborationPermissions.AddAsync(collaborationPermission.toModel());
        await _context.SaveChangesAsync();    
    }

    public async Task delete(CollaborationPermission collaborationPermission)
    {
        _context.CollaborationPermissions.Remove(collaborationPermission.toModel());
        await _context.SaveChangesAsync();    
    }

    public IQueryable<CollaborationPermission> getAll()
    {
        return _context.CollaborationPermissions.Select(c => c.toView());
    }
}