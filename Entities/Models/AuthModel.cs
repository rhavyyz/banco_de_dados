
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Models;

public class AuthModel
{
    [Key]
    public string user_email { get; set; }

    [NotNull]
    public Int64 password { get; set; }

}