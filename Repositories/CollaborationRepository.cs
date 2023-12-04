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

    public async Task<CollaborationModel> update(CollaborationModel collaboration)
    {
        var res = await _context.Collaborations.Where(
                                    e => e.user_email == collaboration.user_email && 
                                      e.guid_post == collaboration.guid_post
                                     ).ExecuteUpdateAsync(
                                        up =>  up. 
                                        SetProperty(collab => collab.guid_Collaboration_permission,
                                                              collaboration.guid_Collaboration_permission)
                                     );
        await _context.SaveChangesAsync();    

        return collaboration;
    }
}