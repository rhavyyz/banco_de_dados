using System.Data.Entity;
using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Interfaces;
// using like = EF.Functions.Like; 
namespace Repositories;

public class PostRepository : IPostRepository
{


    private readonly ApplicationContext _context;

    public PostRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(PostModel post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();  
    }

    public async Task delete(PostModel post)
    {
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();  
    }

    public IQueryable<PostModel> getAll()
    {
        return _context.Posts.AsQueryable();
    }

    public async Task<List<PostModel>> getByCategory(CategoryModel category)
    {
        
        return await getAll().Where(e => e.Categories.Contains(category)).ToListAsync();
    }

    public async Task<List<PostModel>> getByData(DateTime begin, DateTime end)
    {
        return await getAll().Where(e=> e.date >= begin && e.date <= end).ToListAsync();
    }

    public async Task<PostModel> getByGuid(Guid guid)
    {
        return await _context.Posts.SingleOrDefaultAsync(e => e.guid == guid);
    }

    public async Task<List<PostModel>> getByTitle(string title)
    {
        return await getAll().Where(e => EF.Functions.Like(e.title,  $"%{title}%")).ToListAsync();
    }

    public async Task<List<PostModel>> getByUser(UserModel user)
    {
        return (await _context.Users.SingleOrDefaultAsync(e => e.email == user.email)).Posts;
    }

    public async Task<PostModel> update(PostModel post)
    {
        var res = await _context.Posts.Where(
                        e => e.guid == post.guid 
                        ).ExecuteUpdateAsync(
                            e => e
                             .SetProperty(p => p.approved , post.approved)
                             .SetProperty(p => p.subtitle, post.subtitle)
                             .SetProperty(p => p.title, post.title)
                             .SetProperty(p => p.content, post.content)
                             .SetProperty(p => p.date, post.date)
                            );
        await _context.SaveChangesAsync();    

        return post;
    }
}