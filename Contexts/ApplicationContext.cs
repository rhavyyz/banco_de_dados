namespace Contexts;

using Microsoft.EntityFrameworkCore;
using Models;

public class ApplicationContext : DbContext
{

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
    {
    }

    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<CollaborationModel> Collaborations { get; set; }
    public DbSet<CollaborationPermissionModel> CollaborationPermissions { get; set; }
    public DbSet<CommentModel> Comments { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<PostModel> Posts { get; set; }
    public DbSet<UserPermissionModel> UserPermissions { get; set; }
    public DbSet<LikeModel> Likes { get; set; }
    
}