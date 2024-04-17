using Entities.Models;
using System.Linq;
using Entities.Views;

namespace Repositories.Interfaces;
public interface ICategoryRepository
{
    public Task add(Category category);
    public Task delete(Category category);
    public IQueryable<Category> getByPost(Post post);
    public IQueryable<Category> getAll();
}