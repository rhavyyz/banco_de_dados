using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Repositories.Interfaces;

using EfExtensions = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions;
using Entities.Views;
using Entities.Models;

namespace Repositories;

public class CollaborationRepository : ICollaborationRepository
{
    private readonly ApplicationContext _context;

    public CollaborationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task add(Collaboration collaboration)
    {
        await _context.Collaborations.AddAsync(collaboration.toModel());
        await _context.SaveChangesAsync();    
    }

    public async Task delete(Collaboration collaboration)
    {
        _context.Collaborations.Remove(collaboration.toModel());
        await _context.SaveChangesAsync();    
    }

    public IQueryable<Collaboration> getAll()
    {
        var all = EfExtensions.Include(_context.Collaborations, e=> e.CollaborationPermission);

        return all.Select(c => c.toView());
    }

    public IQueryable<Collaboration> getByPost(Post post)
    {
        return getAll().Where(e => e.guid_post == post.guid );
    }

    public IQueryable<Collaboration> getByUser(User user)
    {
        return getAll().Where(e => e.user_email == user.email );
    }

    public async Task<Collaboration> update(Collaboration collaboration)
    {
        CollaborationModel model_col = collaboration.toModel();

        var c = _context.Collaborations.Find(model_col.user_email, model_col.guid_post);

        if(model_col.guid_Collaboration_permission != Guid.Empty)
            c.guid_Collaboration_permission = model_col.guid_Collaboration_permission;

        _context.Collaborations.Update(c);
        
        await _context.SaveChangesAsync();    

        return c.toView();
    }
}