using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using WebApi.Helpers;
using Models;
using System.Data.Entity;

namespace Repositories;

public class CategoryRepository : ICategoryRepository
{

    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(CategoryModel category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task delete(CategoryModel category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public IQueryable<CategoryModel> getAll()
    {
        return _context.Categories.AsQueryable();
    }

    public List<CategoryModel> getByPost(PostModel post)
    {
        var all = EfExtensions.Include(_context.Posts, e=> e.Categories);

        var p = all.Where(e => e.guid == post.guid).FirstOrDefault(); 

        return p.Categories;
    }
}