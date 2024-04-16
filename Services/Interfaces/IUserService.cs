using Models;
using Views;
namespace Services.Interfacess;

public interface IUserService
{


    public Task add (User user);
    public Task delete (User user);
    public Task<User> update (User user);
    public IQueryable<User> getAll ();
    public List<User> getByName (string name);
    public User getByEmail (string email);
}