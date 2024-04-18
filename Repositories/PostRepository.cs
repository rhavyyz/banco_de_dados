using System.Data.Entity;
using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Entities.Views;
using Entities.Models;


// using like = EF.Functions.Like; 
namespace Repositories;

public class PostRepository : IPostRepository
{
    private readonly ApplicationContext _context;

    public PostRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(Post post)
    {
        await _context.Posts.AddAsync(post.toModel());
        await _context.SaveChangesAsync();  
    }

    public async Task delete(Post post)
    {
        _context.Posts.Remove(post.toModel());
        await _context.SaveChangesAsync();  
    }

    public IQueryable<PostModel> getAllModels()
    {

        var all = EfExtensions.Include(
                  EfExtensions.Include(
                  EfExtensions.Include(_context.Posts, e=> e.Likes), e => e.User), e => e.Categories);

        return all;
    }

    public IQueryable<PostPreview> getAll()
    {
        return getAllModels().Select(p => p.ToPreview());
    }

    public  IQueryable<PostPreview> getByCategory(Category category)
    {
        return getAllModels()
                    .Where(e => e.Categories.Contains(category.toModel()))
                    .Select(p => p.ToPreview());
    }

    public IQueryable<PostPreview> getByDate(DateTime begin, DateTime end)
    {
        return getAllModels()
                    .Where(e=> e.date >= begin && e.date <= end)
                    .Select(p => p.ToPreview());
    }

    public async Task<Post> getByGuid(Guid guid)
    {
        var p = getAllModels().Where(e => e.guid == guid).FirstOrDefault(); 

        return p.toView();
    }

    public IQueryable<PostPreview> getByTitle(string title)
    {
        return getAllModels()
                    .Where(e => EF.Functions.Like(e.title,  $"%{title}%"))
                    .Select(p => p.ToPreview());
    }

    public async Task<IQueryable<PostPreview>> getByUser(User user)
    {
        var all = EfExtensions.Include(_context.Users, e=> e.Posts);

        var u = all.Where(e => e.email == user.email).FirstOrDefault(); 

        return u.Posts.Select(p => p.ToPreview()).AsQueryable();
    }

    public async Task<Post> update(Post post)
    {
        var p = _context.Posts.Find(post.guid);

        if(post.subtitle != null)
            p.subtitle = post.subtitle;
        if(post.content != null)
            p.content = post.content;
        if(post.title != null)
            p.title = post.title;
        if(post.approved != false)
            p.approved = post.approved;
        
        p.date = DateTime.Now;

        _context.Posts.Update(p);
        
        await _context.SaveChangesAsync();

        return p.toView();
    }
}