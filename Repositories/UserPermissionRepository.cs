using Contexts;
using Models;
using Repositories.Interfaces;


namespace Repositories;

public class UserPermissionRepository : IUserPermissionRepository
{

    private readonly ApplicationContext _context;

    public UserPermissionRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(UserPermissionModel userPermission)
    {
        throw new NotImplementedException();
    }

    public void delete(UserPermissionModel userPermission)
    {
        throw new NotImplementedException();
    }
}