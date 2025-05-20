using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Domain;

namespace AutoPartsSite.Application.Profiles;

public class CollaborationRequestProfile : Profile
{
    public CollaborationRequestProfile()
    {
        CreateMap<CollaborationRequest, CollaborationRequestDto>();

        CreateMap<CollaborationRequestDto, CollaborationRequest>()
            .ConstructUsing(dto => new CollaborationRequest(
                dto.CompanyName, dto.ContactPerson, dto.Email, dto.Phone, dto.Message));
    }
}
