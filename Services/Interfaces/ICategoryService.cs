using Models;
using Views;

namespace Services.Interfacess;
public interface ICategoryService
{
    public static Category ModelToView(CategoryModel category)
    {
        CategoryModel aux = new CategoryModel{
            name = category.name,
            guid = category.guid,
            Parent = category.Parent,
            guid_parent = category.guid_parent,
        };

        List<Category.CategoryElement> parent_list = new List<Category.CategoryElement>();

        while ((aux = aux.Parent) != null)
        {
            parent_list.Add(new Category.CategoryElement{
                guid = aux.guid,
                name = aux.name
                });
        
        }
        
        return new Category{
            guid = category.guid,
            name = category.name,
            parents = parent_list            
        };
    }
    public static CategoryModel ViewToModel(Category category)
    {
        var c = new CategoryModel{
            guid = category.guid,
            name = category.name,
            // AQUI A GNT TORCE PRA ELE CARREGAR AS COISAS CASO A GNT PRECISE            
        };

        if( category.parents.Count > 0 )
            c.guid_parent = category.parents.Last().guid;

        return c;
    }
    public  Task add(Category category);
    public  Task delete(Category category);
    public  List<Category> getByPost(Post post);

    public List<Category> getAll();

}