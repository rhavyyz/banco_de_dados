using System.Data.Entity;
using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Entities.Views;
using Entities.Models;

namespace Repositories;

public class UserRepository : IUserRepository
{

    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(User user)
    {
        await _context.Users.AddAsync(user.toModel());
        await _context.SaveChangesAsync();
    }

    public async Task delete(User user)
    {
        _context.Users.Remove(user.toModel());
        await _context.SaveChangesAsync();    
    }

    public IQueryable<UserModel> getAllModels()
    {
        var all = EfExtensions.Include(_context.Users, e=> e.UserPermission);

        return all;
    }

    public IQueryable<User> getAll()
    {
        return getAllModels().Select(u => u.toView());
    }


    public IQueryable<User> getByName(string name)
    {        
        return getAll().Where(e => EF.Functions.Like(e.name,  $"%{name}%")); 
    }

    public User getByEmail(string email)
    {
        return getAll().Where(e => e.email == email).FirstOrDefault(); 
    }

    // This no logical sense aparently
    public async Task<User> update(User user)
    {
        var u = _context.Users.Find(user.email);

        var userModel = user.toModel();

        if(userModel.guid_permission != Guid.Empty)
            u.guid_permission = userModel.guid_permission;
        if(user.name != null)
            u.name = user.name;
        if(userModel.pass_hash != -1)
            u.pass_hash = userModel.pass_hash;

        _context.Users.Update(u);
        
        await _context.SaveChangesAsync();    

        return u.toView();
    }
}