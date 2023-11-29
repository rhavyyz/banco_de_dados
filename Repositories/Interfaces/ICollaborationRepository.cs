namespace Repositories.Interfaces;
using Models;

public interface ICollaborationRepository
{
    public void add(CollaborationModel collaboration);
    public void delete(CollaborationModel collaboration);
    public CollaborationModel update(CollaborationModel collaboration);
}