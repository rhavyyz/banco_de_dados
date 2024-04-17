using System.Data.Entity;
using WebApi.Helpers;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Entities.Views;

namespace Repositories;

public class CommentRepository : ICommentRepository
{


    private readonly ApplicationContext _context;

    public CommentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(Comment comment)
    {
        await _context.Comments.AddAsync(comment.toModel());
        await _context.SaveChangesAsync();  
    }

    public async Task delete(Comment comment)
    {
        _context.Comments.Remove(comment.toModel());
        await _context.SaveChangesAsync();  
    }

    public IQueryable<Comment> getByPost(Post post)
    {
        var all = EfExtensions.Include(_context.Posts, e=> e.Comments)
                              .ThenInclude(e=>e.User);

        var p = all.Where(e => e.guid == post.guid).FirstOrDefault(); 

        return p.Comments.Select(c => c.toView()).AsQueryable();
    }
}