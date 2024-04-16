using Models;
using Views;

namespace Services.Interfacess;
public interface ICategoryService
{
    
    public  Task add(Category category);
    public  Task delete(Category category);
    public  List<Category> getByPost(Post post);

    public List<Category> getAll();

}