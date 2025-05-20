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
    internal class ContactService: IContactService
    {
        private readonly IRepository<ContactMessage> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<ContactMessage> contactRepository,IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            
        }

        public async Task AddPostAsync(ContactMessageDto contactMessageDto)
        {
            var message = _mapper.Map<ContactMessage>(contactMessageDto);
            await _contactRepository.AddAsync(message);

        }
    }
}
