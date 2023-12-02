using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
namespace Repositories.Interfaces;

public interface ILikeRepository
{

    public Task add(LikeModel like);
    public Task delete(LikeModel like);
    public Task<List<LikeModel>> getByUser(UserModel user);
    public Task<List<LikeModel>> getByPost(PostModel post);
}