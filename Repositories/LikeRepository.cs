using System.Data.Entity;
using WebApi.Helpers;
using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly ApplicationContext _context;

    public LikeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(LikeModel like)
    {
        await _context.Likes.AddAsync(like);
        await _context.SaveChangesAsync();      
    }

    public async Task delete(LikeModel like)
    {
        _context.Likes.Remove(like);
        await _context.SaveChangesAsync();  
    }

    public List<LikeModel> getByPost(PostModel post)
    {
        var all = EfExtensions.Include(_context.Posts, e=> e.Likes);

        var p = all.Where(e => e.guid == post.guid).FirstOrDefault(); 

        return p.Likes;
    }

    public List<LikeModel> getByUser(UserModel user)
    {
        var all = EfExtensions.Include(_context.Users, e=> e.Likes);

        var u = all.Where(e => e.email == user.email).FirstOrDefault(); 

        return u.Likes;
    }
}