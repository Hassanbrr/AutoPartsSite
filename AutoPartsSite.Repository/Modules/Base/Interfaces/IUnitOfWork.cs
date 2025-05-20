using AutoPartsSite.Repository.Modules.BlogPost.Interfaces;
using AutoPartsSite.Repository.Modules.CollaborationRequest.Interfaces;
using AutoPartsSite.Repository.Modules.ContactMessage.Interfaces;

namespace AutoPartsSite.Repository.Modules.Base.Interfaces;

public interface IUnitOffWork
{
    IBlogRepository Blog { get; }
    IContactMessageRepository ContactMessage { get; }
    ICollaborationRequestRepository CollaborationRequest { get; }

    Task SaveChangesAsync();

}