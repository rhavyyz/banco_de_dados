using Contexts;
using Models;
using Repositories.Interfaces;
namespace Repositories;

public class CollaborationRepository : ICollaborationRepository
{


    private readonly ApplicationContext _context;

    public CollaborationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void add(CollaborationModel collaboration)
    {
        throw new NotImplementedException();
    }

    public void delete(CollaborationModel collaboration)
    {
        throw new NotImplementedException();
    }

    public CollaborationModel update(CollaborationModel collaboration)
    {
        throw new NotImplementedException();
    }
}