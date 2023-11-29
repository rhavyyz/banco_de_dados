using Models;

namespace Repositories.Interfaces;
public interface ICategotyRepository
{

    public void add(CategoryModel category);
    public void delete(CategoryModel category);
    public List<CategoryModel> getByPost(PostModel post);

}