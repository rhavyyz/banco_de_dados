// CREATE TABLE User_Permission
// (
//   	id int,
//   	name char(20),
// 	    PRIMARY KEY(id)
// );



using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Models;

[PrimaryKey(nameof(guid))]
[Index(nameof(name), IsUnique = true)]
public class UserPermissionModel
{
    public Guid guid { get; set; } 

    [MaxLength(255)]

    [Required]
    public string name { get; set; }

    public virtual List<UserModel> Users { get; set; }
}