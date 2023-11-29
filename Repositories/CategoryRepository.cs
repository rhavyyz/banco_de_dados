using Repositories.Interfaces;
using Contexts;
using Models;
namespace Repositories;

public class CategoryRepository : ICategotyRepository
{

    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(CategoryModel category)
    {
        throw new NotImplementedException();
    }

    public void delete(CategoryModel category)
    {
        throw new NotImplementedException();
    }

    public List<CategoryModel> getByPost(PostModel post)
    {
        throw new NotImplementedException();
    }
}