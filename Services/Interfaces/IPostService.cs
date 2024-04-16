using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Views;
namespace Services.Interfacess;
using Util = Utils.Utils;

public interface IPostService
{


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