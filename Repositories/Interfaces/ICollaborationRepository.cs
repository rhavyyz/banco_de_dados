namespace Repositories.Interfaces;
using Models;

public interface ICollaborationRepository
{
    public Task add(CollaborationModel collaboration);
    public Task delete(CollaborationModel collaboration);
    public Task<CollaborationModel> update(CollaborationModel collaboration);
}