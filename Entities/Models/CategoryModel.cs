// CREATE TABLE Category
// (
// 	id int,
//   	id_parent int,
//   	name char(80),
//   	PRIMARY key(id),
//   	FOREIGN key(id_parent) REFERENCES Category(id)
// );

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Entities.Views;

namespace Entities.Models;

public class CategoryModel
{
    [Key]
    public Guid guid { get; set; }

    [MaxLength(80)]
    public string name { get; set; } = "";

    [ForeignKey(nameof(Parent))]
    public Guid? guid_parent;

    // Navigation properties
    public virtual CategoryModel Parent { get; set; }  = null;
    public virtual List<PostModel> Posts { get; set; }

    public Category toView()
    {
        CategoryModel aux = new CategoryModel{
            name = this.name,
            guid = this.guid,
            Parent = this.Parent,
            guid_parent = this.guid_parent,
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
            guid = this.guid,
            name = this.name,
            parents = parent_list            
        };
    }

}