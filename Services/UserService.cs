using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

using Services.Interfaces;
using Views;
namespace Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task add (User user)
    {
        await _repository.add(IUserService.ViewToModel(user));
    }
    public async Task delete (User user)
    {
        await _repository.delete(IUserService.ViewToModel(user));
    }
    public async Task<User> update (User user)
    {
        return IUserService.ModelToView( 
            await _repository.update(IUserService.ViewToModel(user))  
        );
    }
    public IQueryable<User> getAll ()
    {
        List<User> users = new List<User>();

        foreach (UserModel user in _repository.getAll())
            users.Add( IUserService.ModelToView(user) );

        return users.AsQueryable();    
    }
    public List<User> getByName (string name)
    {
        List<User> users = new List<User>();

        var mUser = _repository.getByName(name);

        foreach (UserModel user in mUser)
            users.Add(IUserService.ModelToView(user) );

        return users;
    }
    public User getByEmail (string email)
    {
        return IUserService.ModelToView(
            _repository.getByEmail(email)
        );    
    }

}