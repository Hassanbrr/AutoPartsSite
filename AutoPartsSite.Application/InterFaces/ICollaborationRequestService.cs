using AutoPartsSite.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsSite.Application.InterFaces
{
    public interface ICollaborationRequestService
    {
        Task AddPostAsync(CollaborationRequestDto collaborationRequestDto);

    }
}
