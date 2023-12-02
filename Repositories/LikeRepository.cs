using System.Data.Entity;
using WebApi.Helpers;
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

    public async Task<List<LikeModel>> getByPost(PostModel post)
    {
        var p = await _context.Posts.SingleOrDefaultAsync(e => e.guid == post.guid);

        return p.Likes;
    }

    public async Task<List<LikeModel>> getByUser(UserModel user)
    {
        var u = await _context.Users.SingleOrDefaultAsync(e => e.email == user.email);

        return u.Likes;
    }
}