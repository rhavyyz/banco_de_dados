using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Entities.Models;
using Entities.Views;
namespace Repositories.Interfaces;

public interface ILikeRepository
{
    public Task add(Guid guid_post, string user_email);
    public Task delete(Guid guid_post, string user_email);
    public UserLikes getByUser(User user);
    public PostLikes getByPost(Post post);
}