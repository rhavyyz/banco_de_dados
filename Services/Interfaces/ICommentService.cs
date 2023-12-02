using Models;
namespace Services.Interfaces;

public interface ICommentService
{


    public Task add(CommentModel comment);
    public Task delete(CommentModel comment);
    public Task<List<CommentModel>> getByPost(PostModel post);

}