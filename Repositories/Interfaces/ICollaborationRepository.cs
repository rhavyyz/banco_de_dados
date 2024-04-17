namespace Repositories.Interfaces;
using Entities.Models;
using Entities.Views;

public interface ICollaborationRepository
{
    public Task add(Collaboration collaboration);
    public Task delete(Collaboration collaboration);
    public Task<Collaboration> update(Collaboration collaboration);
    public IQueryable<Collaboration> getAll();
    public IQueryable<Collaboration> getByPost(Post post);
    public IQueryable<Collaboration> getByUser(User user);

}