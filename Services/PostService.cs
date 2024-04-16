using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;
namespace Servicess;



public class PostService : IPostService
{

    private readonly IPostRepository _repository;

    public PostService(IPostRepository repository)
    {
        _repository = repository;
    }
    public async Task add (Post post)
    {
        await _repository.add(IPostService.ViewToModel(post));
    }
    public async Task delete (Post post)
    {
        await _repository.delete(IPostService.ViewToModel(post));
    }
    public async Task<Post> update (Post post)
    {
        return IPostService.ModelToView( 
            await _repository.update(IPostService.ViewToModel(post))  
        );
    }
    // FOR SURE IT WILL NEED OPTIMIZATION  
    public IQueryable<PostPreview> getAll()
    {
        List<PostPreview> posts = new List<PostPreview>();

        foreach (PostModel post in _repository.getAll())
            posts.Add( IPostService.ModelToPreview( post) );

        return posts.AsQueryable();
    }
    public  List<PostPreview> getByTitle (string title)
    {
        List<PostPreview> posts = new List<PostPreview>();

        var mPosts = _repository.getByTitle(title);

        foreach (PostModel post in mPosts)
            posts.Add( IPostService.ModelToPreview( post) );

        return posts;
    }
    public async Task<List<PostPreview>> getByCategory (Category category)
    {
        List<PostPreview> posts = new List<PostPreview>();

        var mPosts = _repository.getByCategory(ICategoryService.ViewToModel(category));

        foreach (PostModel post in mPosts)
            posts.Add( IPostService.ModelToPreview( post) );

        return posts;

    }
    public async Task<List<PostPreview>> getByUser (User user)
    {
        List<PostPreview> posts = new List<PostPreview>();

        var mPosts = await _repository.getByUser(IUserService.ViewToModel(user));

        foreach (PostModel post in mPosts)
            posts.Add( IPostService.ModelToPreview( post) );

        return posts;
    }
    public List<PostPreview> getByDate (DateTime begin, DateTime end)
    {
        List<PostPreview> posts = new List<PostPreview>();

        var mPosts =  _repository.getByDate(begin, end);

        foreach (PostModel post in mPosts)
            posts.Add(IPostService.ModelToPreview( post) );

        return posts;
    }
    public async Task<Post> getByGuid(Guid guid)
    {
        return IPostService.ModelToView(
            await _repository.getByGuid(guid)
        );
    }

}