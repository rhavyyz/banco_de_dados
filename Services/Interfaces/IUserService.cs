using Models;
namespace Services.Interfaces;

public interface IUserService
{
    public Task add (UserModel user);
    public Task delete (UserModel user);
    public Task<UserModel> update (UserModel user);
    public IQueryable<UserModel> getAll ();
    public Task<List<UserModel>> getByName (string name);
    public Task<UserModel> getSingle (string email);
}