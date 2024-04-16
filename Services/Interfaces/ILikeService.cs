using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
using Views;
namespace Services.Interfacess;

public interface ILikeService
{


    public Task add(Guid guid_post, string user_email);
    public Task delete(Guid guid_post, string user_email);
    public UserLikes getByUser(User user);
    public PostLikes getByPost(Post post);
}