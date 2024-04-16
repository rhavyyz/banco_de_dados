using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;
namespace Servicess;



public class UserPermissionService : IUserPermissionService
{

    private readonly IUserPermissionRepository _repository;

    public UserPermissionService(IUserPermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task add(UserPermission userPermission)
    {
        await _repository.add(IUserPermissionService.ViewToModel(userPermission));
    }
    public async Task delete(UserPermission userPermission)
    {
        await _repository.delete(IUserPermissionService.ViewToModel(userPermission));
    }

    public IQueryable<UserPermission> getAll()
    {
        List<UserPermission> userPermissions = new List<UserPermission>();

        var mUserPermissions = _repository.getAll();

        foreach(var u in mUserPermissions)
            userPermissions.Add(IUserPermissionService.ModelToView(u));
    
        return userPermissions.AsQueryable();
    }
}