using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Models;
using Repositories.Interfaces;
using Util = Utils.Utils;
using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;

namespace Repositories;

public class CollaborationRepository : ICollaborationRepository
{
    private readonly ApplicationContext _context;

    public CollaborationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(CollaborationModel collaboration)
    {
        await _context.Collaborations.AddAsync(collaboration);
        await _context.SaveChangesAsync();    
    }

    public async Task delete(CollaborationModel collaboration)
    {
        _context.Collaborations.Remove(collaboration);
        await _context.SaveChangesAsync();    
    }

    public IQueryable<CollaborationModel> getAll()
    {
        var all = EfExtensions.Include(_context.Collaborations, e=> e.CollaborationPermission);

        return all;
    }

    public IQueryable<CollaborationModel> getByPost(PostModel post)
    {
        return getAll().Where(e => e.guid_post == post.guid );
    }

    public IQueryable<CollaborationModel> getByUser(UserModel user)
    {
        return getAll().Where(e => e.user_email == user.email );
    }

    public async Task<CollaborationModel> update(CollaborationModel collaboration)
    {
        var c = _context.Collaborations.Find(collaboration.user_email, collaboration.guid_post);

        if(collaboration.guid_Collaboration_permission != Guid.Empty)
            c.guid_Collaboration_permission = collaboration.guid_Collaboration_permission;

        _context.Collaborations.Update(c);
        
        await _context.SaveChangesAsync();    

        return c;
    }
}