using WebApi.Helpers;
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

    public async Task add(UserPermissionModel userPermission)
    {
        await _context.UserPermissions.AddAsync(userPermission);
        await _context.SaveChangesAsync();
    }

    public async Task delete(UserPermissionModel userPermission)
    {
        _context.UserPermissions.Remove(userPermission);
        await _context.SaveChangesAsync();

    }
}