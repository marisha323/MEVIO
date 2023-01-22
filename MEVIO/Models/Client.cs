namespace MEVIO.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public Enum ClientStatus { get; set; }
        public string? PassportNumber { get; set; }
    }
    public class ClientStatus.Enum
    {
        "Potencial"
        "Explicit"
        "Interested"
    }

}
