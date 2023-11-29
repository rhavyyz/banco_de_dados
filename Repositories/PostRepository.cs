using Contexts;
using Models;
using Repositories.Interfaces;
namespace Repositories;

public class PostRepository : IPostRepository
{


    private readonly ApplicationContext _context;

    public PostRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(PostModel post)
    {
        throw new NotImplementedException();
    }

    public void delete(PostModel post)
    {
        throw new NotImplementedException();
    }

    public List<PostModel> getAll()
    {
        throw new NotImplementedException();
    }

    public List<PostModel> getByCategory(CategoryModel category)
    {
        throw new NotImplementedException();
    }

    public List<PostModel> getByData(DateTime date)
    {
        throw new NotImplementedException();
    }

    public PostModel getByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public List<PostModel> getByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public List<PostModel> getByUser(UserModel user)
    {
        throw new NotImplementedException();
    }

    public PostModel update(PostModel post)
    {
        throw new NotImplementedException();
    }
}