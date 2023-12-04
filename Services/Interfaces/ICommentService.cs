using Models;
using Views;
namespace Services.Interfaces;

public interface ICommentService
{
    public static Comment ModelToView(CommentModel comment) 
    {
        return new Comment{
            guid = comment.guid,
            guid_post = comment.guid_post,
            content = comment.content, 
            post_title = comment.Post.title,
            publish_date = comment.publish_date,
            user_email = comment.user_email,
            username = comment.User.name
        };
    }

    public static CommentModel ViewToModel(Comment comment)
    {
        return new CommentModel{
            guid = comment.guid,
            content = comment.content,
            guid_post = comment.guid_post,
            publish_date = comment.publish_date,
            user_email = comment.user_email
        };
    }
    public Task add(Comment comment);
    public Task delete(Comment comment);
    public List<Comment> getByPost(Post post);
}