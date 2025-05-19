namespace AutoPartsSite.Domain;
 

 
    public class ContactMessage
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
        public DateTime SentDate { get; private set; }

        public ContactMessage(string name, string email, string subject, string message)
        {
            Name = name;
            Email = email;
            Subject = subject;
            Message = message;
            SentDate = DateTime.UtcNow; // ذخیره خودکار زمان ارسال
        }

        protected ContactMessage() { }
    }
 