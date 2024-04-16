using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;
namespace Servicess;



public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task add(Category category)
    {
        await _repository.add(ICategoryService.ViewToModel(category));
    }

    public async Task delete(Category category)
    {
        await _repository.delete(ICategoryService.ViewToModel(category));
    }

    public List<Category> getAll()
    {
        return Util.toList<CategoryModel, Category>(_repository.getAll(), ICategoryService.ModelToView);
    }

    public List<Category> getByPost(Post post)
    {
        List<CategoryModel> mCategories = _repository.getByPost(IPostService.ViewToModel(post));

        List<Category> categories = new List<Category>();

        foreach (CategoryModel c in mCategories)
            categories.Add(ICategoryService.ModelToView(c));

        return categories;
    }


}