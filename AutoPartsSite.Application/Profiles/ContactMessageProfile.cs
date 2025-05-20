using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Domain;

namespace AutoPartsSite.Application.Profiles;

public class ContactMessageProfile : Profile
{
    public ContactMessageProfile()
    {
        CreateMap<ContactMessage, ContactMessageDto>();
        CreateMap<ContactMessageDto, ContactMessage>()
            .ConstructUsing(dto => new ContactMessage(
                dto.Name, dto.Email, dto.Subject, dto.Message));
    }
}
