namespace Mvc.Models
{
    public class Client : Generic
    {
        public string Email { get; set; }

 
        public string PhoneNumber { get; set; }

        public DateOnly DataBirth { get; set; }

        public DateTime RegisteredIn { get; set; }
     }
}
