using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Domain;
using AutoPartsSite.Repository.Modules.Base.Interfaces;

namespace AutoPartsSite.Application.Services
{
    public class CollaborationRequestService : ICollaborationRequestService
    {

        private readonly IRepository<CollaborationRequest> _collaborationRepository;
        private readonly IMapper _mapper;
        public CollaborationRequestService(IRepository<CollaborationRequest> collaborationRepository, IMapper mapper)
        {
            _collaborationRepository = collaborationRepository;
            _mapper = mapper;
        }
        public async Task AddPostAsync(CollaborationRequestDto collaborationRequestDto)
        {
            var collaboration = _mapper.Map<CollaborationRequest>(collaborationRequestDto);
            await _collaborationRepository.AddAsync(collaboration);
        }
    }
}
