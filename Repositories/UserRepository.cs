using Contexts;
using Models;
using Repositories.Interfaces;
namespace Repositories;

public class UserRepository : IUserRepository
{

    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(UserModel user)
    {
        throw new NotImplementedException();
    }

    public void delete(UserModel user)
    {
        throw new NotImplementedException();
    }

    public List<UserModel> getAll()
    {
        throw new NotImplementedException();
    }

    public List<UserModel> getByName(string name)
    {
        throw new NotImplementedException();
    }

    public UserModel getSingle(string email)
    {
        throw new NotImplementedException();
    }

    public UserModel update(UserModel user)
    {
        throw new NotImplementedException();
    }
}