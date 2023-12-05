namespace Repositories.Interfaces;
using Models;

public interface ICollaborationRepository
{
    public Task add(CollaborationModel collaboration);
    public Task delete(CollaborationModel collaboration);
    public Task<CollaborationModel> update(CollaborationModel collaboration);
    public IQueryable<CollaborationModel> getAll();
    public IQueryable<CollaborationModel> getByPost(PostModel post);
    public IQueryable<CollaborationModel> getByUser(UserModel user);

}