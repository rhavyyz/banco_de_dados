using Models;
using Views;

namespace Services.Interfacess;

public interface ICollaborationService
{

    public Task add(Collaboration collaboration);
    public Task delete(Collaboration collaboration);
    public Task<Collaboration> update(Collaboration collaboration);
    public IQueryable<Collaboration> getAll();
    public List<Collaboration> getByPost(Post post);
    public List<Collaboration> getByUser(User user);
}