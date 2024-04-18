using Entities.Models;
using Util;

public class Auth
{
    public string user_email { get; set; }

    public string password { get; set; }

    public AuthModel toModel()
    {
        return new AuthModel{
            user_email = user_email,
            password = (new StringHash(password)).getHash()
        };
    }
}