using Models;
namespace Repositories.Interfaces;

public interface ICommentRepository
{


    public void add(CommentModel comment);
    public void delete(CommentModel comment);
    public List<CommentModel> getByPost(PostModel post);

}