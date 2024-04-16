using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;
namespace Servicess;



public class CollaborationPermissionService : ICollaborationPermissionService
{

    private readonly ICollaborationPermissionRepository _repository;

    public CollaborationPermissionService(ICollaborationPermissionRepository repository)
    {
        _repository = repository;
    }
    public async Task add(CollaborationPermission collaborationPermission)
    {
        await _repository.add(ICollaborationPermissionService.ViewToModel(collaborationPermission)); 
    }
    public async Task delete(CollaborationPermission collaborationPermission)
    {
        await _repository.delete(ICollaborationPermissionService.ViewToModel(collaborationPermission));
    }

    public IQueryable<CollaborationPermission> getAll()
    {
        List<CollaborationPermission> collaborationPermissions= new List<CollaborationPermission>();

        var mCollaborationPermissions = _repository.getAll();

        foreach (var c in mCollaborationPermissions)
            collaborationPermissions.Add(ICollaborationPermissionService.ModelToView(c));

        return collaborationPermissions.AsQueryable();
    }
}