using AutoMapper;
using AutoPartsSite.Application.DTOs;
using AutoPartsSite.Domain;

namespace AutoPartsSite.Application.Profiles;

public class CollaborationRequestProfile : Profile
{
    public CollaborationRequestProfile()
    {
        CreateMap<CollaborationRequest, CollaborationRequestDto>();


    }
}