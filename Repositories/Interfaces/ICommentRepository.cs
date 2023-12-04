using Models;
namespace Repositories.Interfaces;

public interface ICommentRepository
{
    public Task add(CommentModel comment);
    public Task delete(CommentModel comment);
    public List<CommentModel> getByPost(PostModel post);
}