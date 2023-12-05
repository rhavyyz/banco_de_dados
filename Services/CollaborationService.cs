using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;

namespace Services;


public class CollaborationService : ICollaborationService
{

    private readonly ICollaborationRepository _repository;

    public CollaborationService(ICollaborationRepository repository)
    {
        _repository = repository;
    }

    public async Task add(Collaboration collaboration)
    {
        await _repository.add(ICollaborationService.ViewToModel(collaboration)); 
    }

    public async Task delete(Collaboration collaboration)
    {
        await _repository.delete(ICollaborationService.ViewToModel(collaboration));
    }

    public IQueryable<Collaboration> getAll()
    {
        return Util.toList(_repository.getAll(), ICollaborationService.ModelToView).AsQueryable();
    }

    public List<Collaboration> getByPost(Post post)
    {
        return Util.toList(_repository.getByPost(IPostService.ViewToModel(post)).AsQueryable(), ICollaborationService.ModelToView);
        
    }

    public List<Collaboration> getByUser(User user)
    {
        return Util.toList(_repository.getByUser(IUserService.ViewToModel(user)).AsQueryable(), ICollaborationService.ModelToView);
    }

    public async Task<Collaboration> update(Collaboration collaboration)
    {
        return ICollaborationService.ModelToView( 
            await _repository.update(ICollaborationService.ViewToModel(collaboration))
        );
    }
}