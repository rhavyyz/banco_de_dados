using Entities.Models;
using Entities.Views;
namespace Repositories.Interfaces;

public interface ICommentRepository
{
    public Task add(Comment comment);
    public Task delete(Comment comment);
    public IQueryable<Comment> getByPost(Post post);
}