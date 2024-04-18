using Entities.Views;

namespace Repositories.Interfaces;

public interface IAuthRepository
{
    public bool add(Auth auth);

    public bool delete(Auth auth);

    public bool acess(Auth auth);

    public bool update(Auth auth);
}