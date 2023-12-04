using Models;
namespace Repositories.Interfaces;

public interface IUserRepository
{
    public Task add (UserModel user);
    public Task delete (UserModel user);
    public Task<UserModel> update (UserModel user);
    public IQueryable<UserModel> getAll ();
    public List<UserModel> getByName (string name);
    public UserModel getByEmail (string email);
}