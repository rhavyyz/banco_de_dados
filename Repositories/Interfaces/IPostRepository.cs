using Entities.Models;
using Entities.Views;
namespace Repositories.Interfaces;

public interface IPostRepository
{
    public Task add (Post post);
    public Task delete (Post post);
    public Task<Post> update (Post post);
    public IQueryable<PostPreview> getAll();
    public IQueryable<PostPreview> getByTitle (string title);
    public IQueryable<PostPreview> getByCategory (Category category);
    public Task<IQueryable<PostPreview>> getByUser (User user);
    public IQueryable<PostPreview> getByDate (DateTime begin, DateTime end);

    public Task<Post> getByGuid(Guid guid);
}