using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPartsSite.Repository.Context;
using AutoPartsSite.Repository.Modules.Base.Interfaces;
using AutoPartsSite.Repository.Modules.BlogPost.Interfaces;
using AutoPartsSite.Repository.Modules.CollaborationRequest.Interfaces;
using AutoPartsSite.Repository.Modules.ContactMessage.Interfaces;

namespace AutoPartsSite.Repository.Modules.Base.Implements
{
    internal class UnitOfWork : IUnitOffWork
    {
        private readonly ApplicationDbContext _context;


   

        public IBlogRepository Blog { get; private set; }
        public IContactMessageRepository ContactMessage { get; private set; }
        public ICollaborationRequestRepository CollaborationRequest { get; private set; }
        public UnitOfWork(ApplicationDbContext context, IBlogRepository blog, IContactMessageRepository contactMessage, ICollaborationRequestRepository collaborationRequest)
        {
            _context = context;
            Blog = blog;
            ContactMessage = contactMessage;
            CollaborationRequest = collaborationRequest;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
