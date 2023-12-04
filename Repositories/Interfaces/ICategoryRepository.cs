using Models;
using System.Linq;

namespace Repositories.Interfaces;
public interface ICategoryRepository
{
    public Task add(CategoryModel category);
    public Task delete(CategoryModel category);
    public List<CategoryModel> getByPost(PostModel post);
    public IQueryable<CategoryModel> getAll();
}