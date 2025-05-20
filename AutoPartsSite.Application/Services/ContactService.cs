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
    internal class ContactService : IContactService
    {
        private readonly IUnitOffWork _unitOffWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOffWork unitOffWork, IMapper mapper)
        {
            _unitOffWork = unitOffWork;
            _mapper = mapper;
        }

        public async Task AddPostAsync(ContactMessageDto contactMessageDto)
        {
            var message = _mapper.Map<ContactMessage>(contactMessageDto);
            await _unitOffWork.ContactMessage.AddAsync(message);
            await _unitOffWork.SaveChangesAsync();

        }
    }
}
