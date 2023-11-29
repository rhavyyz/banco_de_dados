using Contexts;
using Models;
using Repositories.Interfaces;
namespace Repositories;

public class LikeRepository : ILikeRepository
{


    private readonly ApplicationContext _context;

    public LikeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(UserModel user, PostModel post)
    {
        throw new NotImplementedException();
    }

    public void delete(UserModel user, PostModel post)
    {
        throw new NotImplementedException();
    }

    public List<LikeModel> getByPost(PostModel post)
    {
        throw new NotImplementedException();
    }

    public List<LikeModel> getByUser(UserModel user)
    {
        throw new NotImplementedException();
    }
}