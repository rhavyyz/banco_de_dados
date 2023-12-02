using Models;
using Views;

namespace Services.Interfaces;
public interface ICategotyServices
{
    protected Category toView(CategoryModel category);
    public  Task add(Category category);
    public  Task delete(Category category);
    public  Task<List<Category>> getByPost(PostModel post);

}