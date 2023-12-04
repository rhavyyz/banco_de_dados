using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
namespace Repositories.Interfaces;

public interface ILikeRepository
{
    public Task add(LikeModel like);
    public Task delete(LikeModel like);
    public List<LikeModel> getByUser(UserModel user);
    public List<LikeModel> getByPost(PostModel post);
}