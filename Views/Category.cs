using Models;

namespace Views;
public class Category
{
    public struct CategoryElement
    {
        public string name;
        public Guid guid;
    }
    public List<CategoryElement> parents {get; set;} 
    public Guid guid {get; set;}
    public string name {get; set;}

    public CategoryModel toModel()
    {
        var c = new CategoryModel{
            guid = this.guid,
            name = this.name,
            // AQUI A GNT TORCE PRA ELE CARREGAR AS COISAS CASO A GNT PRECISE            
        };

        if( this.parents.Count > 0 )
            c.guid_parent = this.parents.Last().guid;

        return c;
    }
}