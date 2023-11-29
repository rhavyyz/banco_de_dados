using Contexts;
using Models;
using Repositories.Interfaces;
namespace Repositories;

public class CollaborationPermissionRepository : ICollaborationPermissionRepository
{

    private readonly ApplicationContext _context;

    public CollaborationPermissionRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(CollaborationPermissionModel collaborationPermission)
    {
        throw new NotImplementedException();
    }

    public void delete(CollaborationPermissionModel collaborationPermission)
    {
        throw new NotImplementedException();
    }
}