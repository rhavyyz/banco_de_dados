using Contexts;
using Models;
using Repositories.Interfaces;
namespace Repositories;

public class CommentRepository : ICommentRepository
{


    private readonly ApplicationContext _context;

    public CommentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(CommentModel comment)
    {
        throw new NotImplementedException();
    }

    public void delete(CommentModel comment)
    {
        throw new NotImplementedException();
    }

    public List<CommentModel> getByPost(PostModel post)
    {
        throw new NotImplementedException();
    }
}