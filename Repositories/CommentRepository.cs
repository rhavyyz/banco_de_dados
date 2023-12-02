using System.Data.Entity;
using WebApi.Helpers;
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

    public async Task add(CommentModel comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();  
    }

    public async Task delete(CommentModel comment)
    {
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();  
    }

    public async Task<List<CommentModel>> getByPost(PostModel post)
    {
        var p = await _context.Posts.SingleOrDefaultAsync(e => e.guid == post.guid);

        return p.Comments;
    }
}