namespace Mvc.Models
{
    public class Cadastre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DataBirth { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string? Referency { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool Primary { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
