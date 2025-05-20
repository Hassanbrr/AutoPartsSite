using AutoPartsSite.Application.DTOs;

namespace AutoPartsSite.Application.InterFaces;

public interface IContactService
{
    Task AddPostAsync(ContactMessageDto contactMessageDto);

}