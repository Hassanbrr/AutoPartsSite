using AutoPartsSite.Repository.Context;
using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.CollaborationRequest.Interfaces;

namespace AutoPartsSite.Repository.Modules.CollaborationRequest.Implements;

public class CollaborationRequestRepository : Repository<Domain.CollaborationRequest>,ICollaborationRequestRepository

{
    public CollaborationRequestRepository(ApplicationDbContext context) : base(context)
    {
    }
}