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

    public async Task<Collaboration> update(Collaboration collaboration)
    {
        return ICollaborationService.ModelToView( 
            await _repository.update(ICollaborationService.ViewToModel(collaboration))
        );
    }
}