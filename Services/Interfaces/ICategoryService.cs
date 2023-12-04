using Models;
using Views;

namespace Services.Interfaces;
public interface ICategoryService
{
    public static Category ModelToView(CategoryModel category)
    {
        var aux = category;

        List<Category.CategoryElement> parent_list = new List<Category.CategoryElement>();

        while ((aux = aux.Parent) != null)
            parent_list.Add(new Category.CategoryElement{
                guid = category.guid,
                name = category.name
                });
        
        return new Category{
            guid = category.guid,
            name = category.name,
            parents = parent_list            
        };
    }
    public static CategoryModel ViewToModel(Category category)
    {
        return new CategoryModel{
            guid = category.guid,
            name = category.name
            // AQUI A GNT TORCE PRA ELE CARREGAR AS COISAS CASO A GNT PRECISE            
        };
    }
    public  Task add(Category category);
    public  Task delete(Category category);
    public  List<Category> getByPost(Post post);

    public List<Category> getAll();

}