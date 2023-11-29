using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Models;
namespace Repositories.Interfaces;

public interface ILikeRepository
{

    public void add(UserModel user, PostModel post);
    public void delete(UserModel user, PostModel post);
    public List<LikeModel> getByUser(UserModel user);
    public List<LikeModel> getByPost(PostModel post);
}