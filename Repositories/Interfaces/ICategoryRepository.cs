using Models;

namespace Repositories.Interfaces;
public interface ICategotyRepository
{

    public  Task add(CategoryModel category);
    public  Task delete(CategoryModel category);
    public  Task<List<CategoryModel>> getByPost(PostModel post);

}