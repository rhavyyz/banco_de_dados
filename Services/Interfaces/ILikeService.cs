using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
namespace Services.Interfaces;

public interface ILikeService
{

    public Task add(LikeModel like);
    public Task delete(LikeModel like);
    public Task<List<LikeModel>> getByUser(UserModel user);
    public Task<List<LikeModel>> getByPost(PostModel post);
}