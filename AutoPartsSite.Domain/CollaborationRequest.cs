namespace AutoPartsSite.Domain;

public class CollaborationRequest
{
    public int Id { get; private set; }
    public string CompanyName { get; private set; }
    public string ContactPerson { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Message { get; private set; }
    public DateTime RequestDate { get; private set; }

    public CollaborationRequest(string companyName, string contactPerson, string email, string phone, string message)
    {
        CompanyName = companyName;
        ContactPerson = contactPerson;
        Email = email;
        Phone = phone;
        Message = message;
        RequestDate = DateTime.UtcNow;
    }

    protected CollaborationRequest() { }
}
