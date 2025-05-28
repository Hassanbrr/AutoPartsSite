namespace AutoPartsSite.Domain;
 

 
    public class ContactMessage
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
        public DateTime SentDate { get; private set; }

     
        protected ContactMessage() { }
    }
 