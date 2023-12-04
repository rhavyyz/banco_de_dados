using Models;
namespace Repositories.Interfaces;

public interface IPostRepository
{
    public Task add (PostModel post);
    public Task delete (PostModel post);
    public Task<PostModel> update (PostModel post);
    public IQueryable<PostModel> getAll();
    public List<PostModel> getByTitle (string title);
    public List<PostModel> getByCategory (CategoryModel category);
    public Task<List<PostModel>> getByUser (UserModel user);
    public List<PostModel> getByDate (DateTime begin, DateTime end);

    public Task<PostModel> getByGuid(Guid guid);
}