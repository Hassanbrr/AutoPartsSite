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

        private readonly IUnitOffWork _unitOffWork;
        private readonly IMapper _mapper;

        public CollaborationRequestService(IUnitOffWork unitOffWork, IMapper mapper)
        {
            _unitOffWork = unitOffWork;
            _mapper = mapper;
        }
        public async Task AddPostAsync(CollaborationRequestDto collaborationRequestDto)
        {
            var collaboration = _mapper.Map<CollaborationRequest>(collaborationRequestDto);
            await _unitOffWork.CollaborationRequest.AddAsync(collaboration);
            await _unitOffWork.SaveChangesAsync();

        }
    }
}
