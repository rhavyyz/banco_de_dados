using WebApi.Helpers;
using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;


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

    public IQueryable<UserPermissionModel> getAll()
    {
        return _context.UserPermissions.AsQueryable();
    }
}