using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;
namespace Services;


public class CommentService : ICommentService
{

    private readonly ICommentRepository _repository;

    public CommentService(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task add(Comment comment)
    {
        await _repository.add( ICommentService.ViewToModel(comment));
    }

    public async Task delete(Comment comment)
    {
        await _repository.delete( ICommentService.ViewToModel(comment));
    }

    public List<Comment> getByPost(Post post)
    {
        List<CommentModel> mComments = _repository.getByPost( IPostService.ViewToModel( post) );
    
        List<Comment> comments = new List<Comment>();

        foreach (CommentModel c in mComments)
            comments.Add(ICommentService.ModelToView(c));
        
        return comments;
    }
}