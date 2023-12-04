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

namespace Models;

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
}