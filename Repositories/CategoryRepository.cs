using Repositories.Interfaces;
using WebApi.Helpers;
using Models;
using System.Data.Entity;

namespace Repositories;

public class CategoryRepository : ICategotyRepository
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

    public async Task<List<CategoryModel>> getByPost(PostModel post)
    {
        var p = await _context.Posts.SingleOrDefaultAsync(e => e.guid == post.guid);

        return p.Categories;
    }
}