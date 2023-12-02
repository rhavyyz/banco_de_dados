using System.Data.Entity;
using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
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

    public async Task add(UserModel user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task delete(UserModel user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();    
    }

    public IQueryable<UserModel> getAll()
    {
        return _context.Users.AsQueryable();
    }

    public async Task<List<UserModel>> getByName(string name)
    {
        return await getAll().Where(e => e.name == name).ToListAsync(); 
    }

    public async Task<UserModel> getSingle(string email)
    {
        return await getAll().SingleOrDefaultAsync(e => e.email == email); 
    }

    public async Task<UserModel> update(UserModel user)
    {
        var res = await _context.Users.Where(
                e => e.email == user.email 
                ).ExecuteUpdateAsync(
                    e => e
                        .SetProperty(u => u.guid_permission , user.guid_permission)
                        .SetProperty(u => u.name, user.name)
                        .SetProperty(u => u.pass_hash, user.pass_hash)
                        .SetProperty(u => u.email, user.email)
                    );
        await _context.SaveChangesAsync();    

        return user;
    }
}