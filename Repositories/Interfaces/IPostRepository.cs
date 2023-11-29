using Models;
namespace Repositories.Interfaces;

public interface IPostRepository
{
    public void add (PostModel post);
    public void delete (PostModel post);
    public PostModel update (PostModel post);
    public List<PostModel> getAll();
    public List<PostModel> getByTitle (string title);
    public List<PostModel> getByCategory (CategoryModel category);
    public List<PostModel> getByUser (UserModel user);
    public List<PostModel> getByData (DateTime date);

    public PostModel getByGuid(Guid guid);
}