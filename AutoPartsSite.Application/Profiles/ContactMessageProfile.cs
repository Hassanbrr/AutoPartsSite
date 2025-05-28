using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Domain;

namespace AutoPartsSite.Application.Profiles;

public class ContactMessageProfile : Profile
{
    public ContactMessageProfile()
    {
        CreateMap<ContactMessage, ContactMessageDto>();

    }
}
