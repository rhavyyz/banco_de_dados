using System.Data.Entity;
using WebApi.Helpers;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Entities.Views;
using Entities.Models;

namespace Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly ApplicationContext _context;

    public LikeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(Guid guid_post, string user_email)
    {
        await _context.Likes.AddAsync(new LikeModel{
            guid_post = guid_post,
            user_email = user_email
        } 
        );
        await _context.SaveChangesAsync();      
    }

    public async Task delete(Guid guid_post, string user_email)
    {
        _context.Likes.Remove(new LikeModel{
            guid_post = guid_post,
            user_email = user_email
        } 
        );
        await _context.SaveChangesAsync();  
    }


    public PostLikes getByPost(Post post)
    {
        var all = EfExtensions.Include(_context.Posts, e=> e.Likes)
                              .ThenInclude(e=> e.User);

        var p = all.Where(e => e.guid == post.guid).FirstOrDefault(); 

        return LikeModel.toPostLikes(p.Likes) ;
    }

    public UserLikes getByUser(User user)
    {
        var all = EfExtensions.Include(_context.Users, e=> e.Likes)
                              .ThenInclude(e=> e.Post);

        var u = all.Where(e => e.email == user.email).FirstOrDefault(); 

        return LikeModel.toUserLikes( u.Likes );
    }


}