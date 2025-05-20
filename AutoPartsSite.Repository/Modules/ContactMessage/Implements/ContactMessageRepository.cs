using AutoPartsSite.Repository.Context;
using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.ContactMessage.Interfaces;

namespace AutoPartsSite.Repository.Modules.ContactMessage.Implements;

public class ContactMessageRepository : Repository<Domain.ContactMessage>,IContactMessageRepository
{
    public ContactMessageRepository(ApplicationDbContext context) : base(context)
    {
    }
}