using System.Data.Entity;
using WebApi.Helpers;
using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Microsoft.EntityFrameworkCore;

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

    public List<CommentModel> getByPost(PostModel post)
    {
        var all = EfExtensions.Include(_context.Posts, e=> e.Comments)
                              .ThenInclude(e=>e.User);

        var p = all.Where(e => e.guid == post.guid).FirstOrDefault(); 

        return p.Comments;
    }
}