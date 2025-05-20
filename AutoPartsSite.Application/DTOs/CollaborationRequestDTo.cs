namespace AutoPartsSite.Application.DTOs;


public class CollaborationRequestDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string ContactPerson { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
    public DateTime RequestDate { get; set; }
}
