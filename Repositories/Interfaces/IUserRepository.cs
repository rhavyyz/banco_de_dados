using Entities.Models;
using Entities.Views;
namespace Repositories.Interfaces;

public interface IUserRepository
{
    public Task add (User user);
    public Task delete (User user);
    public Task<User> update (User user);
    public IQueryable<User> getAll ();
    public IQueryable<User> getByName (string name);
    public User getByEmail (string email);
}