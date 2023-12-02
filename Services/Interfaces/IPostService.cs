using Models;
namespace Services.Interfaces;

public interface IPostService
{
    public Task add (PostModel post);
    public Task delete (PostModel post);
    public Task<PostModel> update (PostModel post);
    public IQueryable<PostModel> getAll();
    public Task<List<PostModel>> getByTitle (string title);
    public Task<List<PostModel>> getByCategory (CategoryModel category);
    public Task<List<PostModel>> getByUser (UserModel user);
    public Task<List<PostModel>> getByData (DateTime begin, DateTime end);

    public Task<PostModel> getByGuid(Guid guid);
}