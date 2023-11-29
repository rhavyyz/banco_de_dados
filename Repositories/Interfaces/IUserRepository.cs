using Models;
namespace Repositories.Interfaces;

public interface IUserRepository
{
    public void add (UserModel user);
    public void delete (UserModel user);
    public UserModel update (UserModel user);
    public List<UserModel> getAll ();
    public List<UserModel> getByName (string name);
    public UserModel getSingle (string email);
}