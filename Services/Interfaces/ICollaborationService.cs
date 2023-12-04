using Models;
using Views;

namespace Services.Interfaces;

public interface ICollaborationService
{
    public static Collaboration ModelToView(CollaborationModel collaboration)
    {
        return new Collaboration{
            guid_post = collaboration.guid_post,
            post_title = collaboration.Post.title,
            user_email = collaboration.user_email,
            user_name = collaboration.User.name,
            permission = ICollaborationPermissionService.ModelToView(collaboration.CollaborationPermission)
        };
    }
    public static CollaborationModel ViewToModel(Collaboration collaboration)
    {
        return new CollaborationModel{
            user_email = collaboration.user_email,
            guid_post = collaboration.guid_post,
            guid_Collaboration_permission = collaboration.permission.guid
        };
    }
    public Task add(Collaboration collaboration);
    public Task delete(Collaboration collaboration);
    public Task<Collaboration> update(Collaboration collaboration);
}