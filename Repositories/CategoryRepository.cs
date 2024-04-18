using Repositories.Interfaces;

using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using WebApi.Helpers;
using Entities.Views;
using System.Data.Entity;
using Entities.Models;

namespace Repositories;

public class CategoryRepository : ICategoryRepository
{

    private readonly ApplicationContext _context;
    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(Category category)
    {
        await _context.Categories.AddAsync(category.toModel());
        await _context.SaveChangesAsync();
    }

    public async Task delete(Category category)
    {
        _context.Categories.Remove(category.toModel());
        await _context.SaveChangesAsync();
    }

    public IQueryable<Category> getAll()
    {
        IQueryable<CategoryModel> all = EfExtensions.Include(_context.Categories, e=> e.Parent);

        return all.Select(c => c.toView());
    }

    public IQueryable<Category> getByPost(Post post)
    {
        var all = EfExtensions.Include(_context.Posts, e=> e.Categories);

        var p = all.Where(e => e.guid == post.guid).FirstOrDefault(); 



        return p.Categories.Select(c=> c.toView()).AsQueryable();
    }
}