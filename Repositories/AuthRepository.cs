using Repositories.Interfaces;
using WebApi.Helpers;

namespace Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly ApplicationContext _context;

    public AuthRepository(ApplicationContext context)
    {
        this._context = context;
    }

    public bool acess(Auth auth)
    {
        return true;

    }

    public bool add(Auth auth)
    {
        return true;
    }

    public bool delete(Auth auth)
    {
        return true;
    }

    public bool update(Auth auth)
    {
        return true;
    }
}