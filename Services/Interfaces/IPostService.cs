using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Views;
namespace Services.Interfaces;
using Util = Utils.Utils;

public interface IPostService
{

    public static PostModel ViewToModel(Post post)
    {
        return new PostModel{
            approved = post.approved,
            content = post.content,
            date = post.date.HasValue ? (DateTime)post.date : DateTime.Now.ToUniversalTime(),
            guid = post.guid,
            user_email = post.user_email,
            title = post.title,
            subtitle = post.subtitle,            
        };
    }
    public static Post ModelToView(PostModel post)
    {
        return new Post {
            approved = post.approved,
            content = post.content,
            date = post.date,
            guid = post.guid,
            user_email = post.user_email,
            title = post.title,
            subtitle = post.subtitle,            
            n_likes = post.Likes.Count,
            username = post.User.name,
            Categories = Util.toList<CategoryModel, Category>(post.Categories.AsQueryable(), ICategoryService.ModelToView)
        };
    }
    // public static PostModel PreviewToModel(PostPreview post);
    public static PostPreview ModelToPreview(PostModel post)
    {
        return new PostPreview{
            date = (DateTime)post.date,
            guid = post.guid,
            subtitle = post.subtitle,
            title = post.title,
        };
    }
    public Task add (Post post);
    public Task delete (Post post);
    public Task<Post> update (Post post);
    public IQueryable<PostPreview> getAll();
    public List<PostPreview> getByTitle (string title);
    public Task<List<PostPreview>> getByCategory (Category category);
    public Task<List<PostPreview>> getByUser (User user);
    public List<PostPreview> getByDate (DateTime begin, DateTime end);
    public Task<Post> getByGuid(Guid guid);
}