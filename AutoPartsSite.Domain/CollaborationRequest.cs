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

  
    protected CollaborationRequest() { }
}
