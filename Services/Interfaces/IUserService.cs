using Models;
using Views;
namespace Services.Interfaces;

public interface IUserService
{

    public static UserModel ViewToModel(User user)
    {
        return new UserModel{
            email = user.email,
            name = user.name,
            guid_permission = user.guid_permission            
        };
    }
    public static User ModelToView(UserModel user)
    {
        Console.WriteLine($"\n\n\n{user.name}\n\n\n");

        return new User{
            email = user.email,
            name = user.name,
            guid_permission = user.UserPermission.guid
        };
    }
    public Task add (User user);
    public Task delete (User user);
    public Task<User> update (User user);
    public IQueryable<User> getAll ();
    public List<User> getByName (string name);
    public User getByEmail (string email);
}