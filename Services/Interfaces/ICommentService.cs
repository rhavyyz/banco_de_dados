using Models;
using Views;
namespace Services.Interfacess;

public interface ICommentService
{


    public Task add(Comment comment);
    public Task delete(Comment comment);
    public List<Comment> getByPost(Post post);
}