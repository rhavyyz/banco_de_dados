// CREATE TABLE Category
// (
// 	id int,
//   	id_parent int,
//   	name char(80),
//   	PRIMARY key(id),
//   	FOREIGN key(id_parent) REFERENCES Category(id)
// );

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models;

public class CategoryModel
{
    [Key]
    public Guid guid { get; set; }

    [MaxLength(80)]
    public string name { get; set; } = "";

    // Navigation properties
    public CategoryModel? Parent { get; set; }  = null;
    public virtual List<PostModel> Posts { get; set; }
}