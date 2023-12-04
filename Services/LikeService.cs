using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;
namespace Services;


public class LikeService : ILikeService
{
    private readonly ILikeRepository _repository;

    public LikeService(ILikeRepository repository)
    {
        _repository = repository;
    }

    public async Task add(Guid guid_post, string user_email)
    {
        await _repository.add(new LikeModel{ 
                                            guid_post = guid_post,
                                            user_email = user_email
                                           });
    }
    public async Task delete(Guid guid_post, string user_email)
    {
        await _repository.delete(new LikeModel{ 
                                               guid_post = guid_post,
                                               user_email = user_email
                                              });
    }
    public UserLikes getByUser(User user)
    {
        return ILikeService.ModelToUserView( 
            _repository.getByUser(IUserService.ViewToModel(user)) 
        );
    }
    public PostLikes getByPost(Post post)
    {
        return ILikeService.ModelToPostView( 
            _repository.getByPost(IPostService.ViewToModel(post)) 
        );
    }
}