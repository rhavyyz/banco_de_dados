using WebApi.Helpers;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Entities.Views;
using Entities.Models;


namespace Repositories;

public class UserPermissionRepository : IUserPermissionRepository
{

    private readonly ApplicationContext _context;

    public UserPermissionRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(UserPermission userPermission)
    {
        await _context.UserPermissions.AddAsync(userPermission.toModel());
        await _context.SaveChangesAsync();
    }

    public async Task delete(UserPermission userPermission)
    {
        _context.UserPermissions.Remove(userPermission.toModel());
        await _context.SaveChangesAsync();

    }

    public IQueryable<UserPermissionModel> getAllModels()
    {
        return _context.UserPermissions;
    }

    public IQueryable<UserPermission> getAll()
    {
        return getAllModels().Select(u => u.toView()).AsQueryable();
    }
}